import {currencies} from "../data/cunrrencyList.js"

document.addEventListener("DOMContentLoaded", function () {
    const getStartedBtn = document.getElementById("btn-GetStarted");
    
    getStartedBtn.addEventListener("click", function () {
        if (localStorage.getItem("username") === null) {
            GetStarted()
            console.log("no name")
            return
        }
        
        ShowCurrencyMenu()
        document.getElementById("btn-GetStarted").style.display = "none"
        DisplayUsername(localStorage.getItem("username"))
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const getStartedBtn = document.getElementById("btn-submitUserName");
    
    getStartedBtn.addEventListener("click", function () {
        AuthorizeUser()
        ShowCurrencyMenu()
        // UnhideResetButton()
    });
});

document.addEventListener("keydown", function(event) {
    let authForm = document.getElementById("getUserName");
    if (authForm.classList.contains("d-block") 
            && !authForm.classList.contains("d-none") 
            && event.key === "Enter") {
        AuthorizeUser()
        ShowCurrencyMenu()
    }
})

document.addEventListener("DOMContentLoaded", function () {
    const getStartedBtn = document.getElementById("btn-currency");
    
    getStartedBtn.addEventListener("click", function () {
        GetPredefinedCurrecnies()
    });
});

function GetStarted() {
    document.getElementById("btn-GetStarted").style.display = "none"
    document.getElementById("getUserName").classList.remove("d-none")
    document.getElementById("getUserName").classList.add("d-block")
}

function AuthorizeUser() {
    let name = document.getElementById("ipt-userName").value
    DisplayUsername(name)
    localStorage.setItem("username", name)
    document.getElementById("getUserName").classList.remove("d-flex")
    document.getElementById("getUserName").classList.add("d-none")
    GetSuccessAlert()
    document.getElementById("div-auth-getStarted").classList.remove("d-flex")
    document.getElementById("div-auth-getStarted").classList.add("d-none")
}

function DisplayUsername(username){
    document.getElementById("out-userName").textContent = "Hello " + username
    document.getElementById("out-userName").classList.remove("d-none")
    document.getElementById("out-userName").classList.add("d-flex")
    document.getElementById("user-dropdown-trigger").textContent = username
    document.getElementById("user-dropdown").classList.remove("d-none")
    document.getElementById("user-dropdown").classList.add("d-flex")
}

function GetSuccessAlert(){
    let successAlert = document.createElement("div")
    successAlert.classList.add("alert", "alert-success", "top-0", "end-0", "m-3")
    successAlert.setAttribute("role", "alert")
    successAlert.innerHTML = '<strong>Success</strong>'
    document.getElementById("out-alert").appendChild(successAlert)

    setTimeout(function() {
        successAlert.classList.remove("d-flex")
        successAlert.classList.add("d-none")
    }, 3000)
}

function ShowCurrencyMenu(){
    document.getElementById("out-currencyList").classList.remove("d-none")
    document.getElementById("out-currencyList").classList.add("d-flex")
}

function GetPredefinedCurrecnies() {
    document.getElementById("btn-currency").style.display = "none"

    GetButtonListOfCurrencies()
}

function GetButtonListOfCurrencies(){
    let currenciesButtonGroup = document.createElement("div")
    let container = document.getElementById("out-currencyBtnGrpChoose1stStep");
    currenciesButtonGroup.classList.add("btn-group")
    currenciesButtonGroup.setAttribute("role", "group")
    
    for (let index = 0; index < currencies.length; index++) {
        let button = document.createElement("button")
        button.setAttribute("type", "button")
        button.classList.add("btn", "btn-primary", "m-1");
        button.textContent = currencies[index]
        button.dataset.currency = currencies[index]; 
        currenciesButtonGroup.appendChild(button)


        if ((index ) % 20 === 0) {
            container.appendChild(currenciesButtonGroup);
            currenciesButtonGroup = document.createElement("div");
        }
    }
}

function GetCheckboxesListOfCurrencies(){
    let currenciesButtonGroup = document.createElement("div")
    let container = document.getElementById("out-currencyCheckBoxesGrpChoose2stStep");
    currenciesButtonGroup.classList.add("btn-group")
    currenciesButtonGroup.setAttribute("role", "group")
    
    for (let index = 0; index < currencies.length; index++) {
        let checkboxInput = document.createElement("input")
        let checkboxLabel = document.createElement("label")
        let checkboxId = "btn-check" + index

        checkboxInput.setAttribute("type", "checkbox")
        checkboxInput.classList.add("btn-check")
        checkboxInput.setAttribute("id", checkboxId)

        checkboxLabel.classList.add("btn")
        checkboxLabel.classList.add("btn-outline-primary")
        checkboxLabel.setAttribute("for", checkboxId)
        checkboxLabel.textContent = currencies[index]
        
        checkboxInput.dataset.currency = currencies[index]; 
        currenciesButtonGroup.appendChild(checkboxInput)
        currenciesButtonGroup.appendChild(checkboxLabel)


        if ((index ) % 20 === 0) {
            container.appendChild(currenciesButtonGroup);
            currenciesButtonGroup = document.createElement("div");
        }
    }
}

document.getElementById("out-currencyBtnGrpChoose1stStep").addEventListener("click", function(event) {
    if (event.target.tagName === "BUTTON") {
        let currency = event.target.dataset.currency
        localStorage.setItem("setCurrency", currency)
        HideCurrencyButtonList1stStep()
        GetCheckboxesListOfCurrencies()
    }
});

document.getElementById("out-currencyCheckBoxesGrpChoose2stStep").addEventListener("click", function(event){
    if (event.target.checked) {
        let currency = event.target.dataset.currency;
        let selectedCurrencies = localStorage.getItem("selectCurrency") || "";

        let currenciesArray = selectedCurrencies ? selectedCurrencies.split(",") : [];

        if (currenciesArray.length === 4) {
            currenciesArray.push(currency);
            localStorage.setItem("selectCurrency", currenciesArray.join(","));
            HideCurrencyCheckboxesList2ndStep()
            Conversion()
            return
        }

        let index = currenciesArray.indexOf(currency);

        if (index !== -1) {
            currenciesArray.splice(index, 1); 
        } else {
            currenciesArray.push(currency); 
        }

        localStorage.setItem("selectCurrency", currenciesArray.join(","));
    }
    else if (event.target.dataset.currency != null){
        let currency = event.target.dataset.currency;
        let selectedCurrencies = localStorage.getItem("selectCurrency") || "";

        let currenciesArray = selectedCurrencies ? selectedCurrencies.split(",") : [];

        let index = currenciesArray.indexOf(currency);

        if (index !== -1) {
            currenciesArray.splice(index, 1);
        } else {
            currenciesArray.push(currency);
        }

        localStorage.setItem("selectCurrency", currenciesArray.join(","));
    }
    
} )

function HideCurrencyButtonList1stStep(){
    document.getElementById("out-currencyBtnGrpChoose1stStep").classList.remove("d-flex")
    document.getElementById("out-currencyBtnGrpChoose1stStep").classList.add("d-none")
}

function HideCurrencyCheckboxesList2ndStep(){
    document.getElementById("out-currencyCheckBoxesGrpChoose2stStep").classList.remove("d-flex")
    document.getElementById("out-currencyCheckBoxesGrpChoose2stStep").classList.add("d-none")
}

function UnhideCurrencyButtonList1stStep(){
    document.getElementById("out-currencyBtnGrpChoose1stStep").classList.remove("d-none")
    document.getElementById("out-currencyBtnGrpChoose1stStep").classList.add("d-flex")
}

function UnhideCurrencyCheckboxesList2ndStep(){
    document.getElementById("out-currencyCheckBoxesGrpChoose2stStep").classList.remove("d-none")
    document.getElementById("out-currencyCheckBoxesGrpChoose2stStep").classList.add("d-flex")
}

async function GetCurrencyAsync(curreccyToGet){
    let link = 'https://v6.exchangerate-api.com/v6/26e3acf6b9e08c4da15f2574/latest/' + curreccyToGet
    let result = await fetch(link)
    let data = await result.json()
    return await data
}

async function DisplayConversion(data) {
    let initCur = data[0];
    let currenciesConversion = data[1];

    let table = document.createElement("table");
    table.style.width = "100%";
    let tableTBody = document.createElement("tbody");

    let tTR = document.createElement("tr");
    let tTd1 = document.createElement("td");
    let tTd2 = document.createElement("td");
    let text = "initial";

    tTd1.textContent = text + ": ";
    tTd2.textContent = initCur;

    tTR.appendChild(tTd1);
    tTR.appendChild(tTd2);
    tableTBody.appendChild(tTR);

    for (let index = 0; index < currenciesConversion.length; index++) {
        let tableTr = document.createElement("tr");
        let tr1 = document.createElement("td");
        let tr2 = document.createElement("td");
        let currency = Object.keys(currenciesConversion[index])[0];
        let conversionRate = currenciesConversion[index][currency];

        tr1.textContent = currency + ": ";
        tr2.textContent = conversionRate;

        tableTr.appendChild(tr1);
        tableTr.appendChild(tr2);
        tableTBody.appendChild(tableTr);
    }

    table.appendChild(tableTBody);
    
    let resultContainer = document.getElementById("out-getAllCurrencies_result");
    resultContainer.innerHTML = ""
    resultContainer.appendChild(table);
    resultContainer.classList.remove("d-none");
    resultContainer.classList.add("d-flex");
}


async function Conversion() {
    let currencyToSearch = localStorage.getItem("setCurrency")
    let selectedCurrencies = localStorage.getItem("selectCurrency") || "";
    let currenciesArray = selectedCurrencies ? selectedCurrencies.split(",") : [];
    let data = await GetCurrencyAsync(currencyToSearch)
    let convertedData = GetConversionResult(data, currenciesArray)
    await DisplayConversion(convertedData)
    await WriteHistory(convertedData)

    CleanLocalstorage()
}

function GetConversionResult(result, currenciesConversion) {
    let conversionArray = [];
    let baseCurrency = result.base_code

    for (let index = 0; index < currenciesConversion.length; index++) {
        let currency = currenciesConversion[index]; 
        let conversion = result.conversion_rates[currency]; 

        conversionArray.push({ [currency]: conversion });
    }

    return [baseCurrency, conversionArray]
}

async function WriteHistory(newHistory) {
    let history = JSON.parse(localStorage.getItem("historyCurrency")) || [];
    let initCurrency = { "initial": newHistory[0] };
    let itemsToAdd = [initCurrency, ...newHistory[1]];

    history.push(itemsToAdd);

    localStorage.setItem("historyCurrency", JSON.stringify(history));

    console.log("Updated history:", history);
}

document.addEventListener("DOMContentLoaded", function(){
    const modalHistory = document.getElementById("user-dropdown-history")

    modalHistory.addEventListener("click", function (event) {
        DrawTableConversionHistory()
    })
})

function DrawTableConversionHistory() {
    let container = document.getElementById("user-history-conversion-body")
    let history = JSON.parse(localStorage.getItem("historyCurrency")) || []

    let table = document.createElement("table");
    table.style.width = "100%";
    let tableTBody = document.createElement("tbody");

    for (let index = 0; index < history.length; index++) {
        for (let y = 0; y < history[index].length; y++) {
            let tableTr = document.createElement("tr");
            let tr1 = document.createElement("td");
            let tr2 = document.createElement("td");
            let currency = Object.keys(history[index][y])[0];
            let conversionRate = history[index][y][currency];

            tr1.textContent = currency + ": ";
            tr2.textContent = conversionRate;

            tableTr.appendChild(tr1);
            tableTr.appendChild(tr2);
            tableTBody.appendChild(tableTr);
        }
    }

    table.appendChild(tableTBody);
    container.innerHTML = ""
    container.appendChild(table);
}

document.addEventListener("DOMContentLoaded", function(){
    let container = document.getElementById("user-history-conversion-modal-close")

    container.addEventListener("click", function(event){
        document.getElementById("user-history-conversion-body").innerHTML = ""
    })
})

function UnhideResetButton(){
    document.getElementById("btn-reset").classList.remove("d-none")
    document.getElementById("btn-reset").classList.add("d-flex")
}

document.getElementById("btn-reset").addEventListener("click", function(event){
    CleanLocalstorage()
    UnhideCurrencyButtonList1stStep()
})

function CleanLocalstorage() {
    localStorage.removeItem("setCurrency")
    localStorage.removeItem("selectCurrency")
}
