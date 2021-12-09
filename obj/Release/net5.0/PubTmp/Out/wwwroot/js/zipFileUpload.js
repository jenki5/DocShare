const closeModalBtns = document.querySelectorAll('.close-x');
const overlays = document.querySelectorAll('.overlay');
const calendarIcon = document.querySelector('.fa-calendar-alt');
const submitNewCaseBtn = document.getElementById('submit-new-cases');
const cards = document.getElementById('patient-cards');
const searchInput = document.getElementById('search-input');
const labOptions = document.getElementById('lab-options');
const caseHistoryBtn = document.getElementById('case-history-btn');
const caseInfoBtn = document.getElementById('case-info-btn');
const newNote = document.getElementById('new-note');
const confirmDeleteBtn = document.getElementById('confirm-delete-btn');
const holdBtn = document.getElementById('hold-btn');
const confirmHoldBtn = document.getElementById('confirm-hold-btn');
const confirmAddSupplierBtn = document.getElementById('confirm-add-supplier-btn');
const addNewSupplierBtns = document.querySelectorAll('.add-new-supplier-btn');
const datePickerStart = document.getElementById('datepickerStart');
const datePickerEnd = document.getElementById('datepickerEnd');
var currentCaseID;
var newCaseFile;
var selectedLab = 3;

console.log(user);

// const nCaseModal = document.getElementById("new-case-modal");
// const nCasesBox = document.getElementById("new-cases-data-points");

// user.company.patientCases.forEach(patientCase => {
//     nCasesBox.appendChild(createNewCaseDataPoint(patientCase.uploadFiles[0]));
// })

// nCaseModal.style.display = 'flex';

loadAllCases();

calendarIcon.addEventListener('click', () => {
    console.log(datePickerStart.value);
    if(!datePickerStart.value.trim()){
        datePickerStart.focus();
    }
    else{
        datePickerEnd.focus();        
    }
})

datePickerStart.addEventListener('blur', () => {
    setTimeout(() => {
        console.log(datePickerStart.value);
        if(datePickerStart.value.trim() && !datePickerEnd.value.trim()){
            datePickerEnd.focus();
        }
        else if(datePickerStart.value.trim() && datePickerEnd.value.trim()){
            const sDate = new Date(datePickerStart.value)
            const eDate = new Date(datePickerEnd.value)
            if(sDate < eDate){
                console.log("Searching");
                searchAllCases();
                datePickerStart.style.border = 'none';
                datePickerEnd.style.border = 'none';
            }
            else{
                datePickerStart.style.border = '3px solid red';
                datePickerEnd.style.border = '3px solid red';
                loadAllCases();
            }
        }
        else if(!datePickerStart.value.trim() || !datePickerEnd.value.trim()){
            loadAllCases();
        }
    }, 200);
})

datePickerEnd.addEventListener('blur', () => {
    setTimeout(() => {
        if(!datePickerStart.value.trim() && datePickerEnd.value.trim()){
            datePickerStart.focus();
        }
        else if(datePickerStart.value.trim() && datePickerEnd.value.trim()){
            const sDate = new Date(datePickerStart.value)
            const eDate = new Date(datePickerEnd.value)
            if(sDate < eDate){
                console.log("Searching");
                searchAllCases();
                datePickerStart.style.border = 'none';
                datePickerEnd.style.border = 'none';
            }
            else{
                datePickerStart.style.border = '3px solid red';
                datePickerEnd.style.border = '3px solid red';
                loadAllCases();
            }
        }
    }, 200)
});

function searchCasesLabDate(startDate, endDate, labID){
    if(startDate < endDate){
        if(user.company.patientCases && user.company.patientCases.length != 0){
            let frstDate = new Date(user.company.patientCases[user.company.patientCases.length - 1].createdAt)
            frstDate.setDate(frstDate.getDate() + 1);
            cards.innerHTML = "";
            for(let i = user.company.patientCases.length - 1; i >= 0; i--){
                const caseDate = new Date(user.company.patientCases[i].createdAt);
                if(caseDate > startDate && caseDate < endDate && user.company.patientCases[i].labID == labID){
                    let date = new Date(user.company.patientCases[i].createdAt)
                    if(date.getDate() != frstDate.getDate()){
                        frstDate = date;
                        cards.appendChild(createDateLine(user.company.patientCases[i]));
                    }
                    cards.appendChild(createCaseCard(user.company.patientCases[i]));
                }
            }
        }
    }
}

function searchCasesDate(startDate, endDate){
    if(startDate < endDate){
        if(user.company.patientCases && user.company.patientCases.length != 0){
            let frstDate = new Date(user.company.patientCases[user.company.patientCases.length - 1].createdAt)
            frstDate.setDate(frstDate.getDate() + 1);
            cards.innerHTML = "";
            for(let i = user.company.patientCases.length - 1; i >= 0; i--){
                const caseDate = new Date(user.company.patientCases[i].createdAt);
                if(caseDate > startDate && caseDate < endDate){
                    let date = new Date(user.company.patientCases[i].createdAt)
                    if(date.getDate() != frstDate.getDate()){
                        frstDate = date;
                        cards.appendChild(createDateLine(user.company.patientCases[i]));
                    }
                    cards.appendChild(createCaseCard(user.company.patientCases[i]));
                }
            }
        }
    }
}

function searchCasesInputDateLab(startDate, endDate, searchVal, labID){
    if(startDate < endDate){
        if(user.company.patientCases && user.company.patientCases.length != 0){
            let frstDate = new Date(user.company.patientCases[user.company.patientCases.length - 1].createdAt)
            frstDate.setDate(frstDate.getDate() + 1);
            cards.innerHTML = "";
            for(let i = user.company.patientCases.length - 1; i >= 0; i--){
                const caseDate = new Date(user.company.patientCases[i].createdAt);
                if(caseDate > startDate && caseDate < endDate && 
                    user.company.patientCases[i].caseName.toLocaleLowerCase().includes(searchVal.toLocaleLowerCase()) &&
                    user.company.patientCases[i].labID == labID
                    ){
                    let date = new Date(user.company.patientCases[i].createdAt)
                    if(date.getDate() != frstDate.getDate()){
                        frstDate = date;
                        cards.appendChild(createDateLine(user.company.patientCases[i]));
                    }
                    cards.appendChild(createCaseCard(user.company.patientCases[i]));
                }
            }
        }
    }
}

function searchCasesInputDate(startDate, endDate, searchVal){
    if(startDate < endDate){
        if(user.company.patientCases && user.company.patientCases.length != 0){
            let frstDate = new Date(user.company.patientCases[user.company.patientCases.length - 1].createdAt)
            frstDate.setDate(frstDate.getDate() + 1);
            cards.innerHTML = "";
            for(let i = user.company.patientCases.length - 1; i >= 0; i--){
                const caseDate = new Date(user.company.patientCases[i].createdAt);
                if(caseDate > startDate && caseDate < endDate && user.company.patientCases[i].caseName.toLocaleLowerCase().includes(searchVal.toLocaleLowerCase())){
                    let date = new Date(user.company.patientCases[i].createdAt)
                    if(date.getDate() != frstDate.getDate()){
                        frstDate = date;
                        cards.appendChild(createDateLine(user.company.patientCases[i]));
                    }
                    cards.appendChild(createCaseCard(user.company.patientCases[i]));
                }
            }
        }
    }
}

function loadAllCases(){
    if(user.company.patientCases && user.company.patientCases.length != 0){
        let frstDate = new Date(user.company.patientCases[user.company.patientCases.length - 1].createdAt)
        frstDate.setDate(frstDate.getDate() + 1);
        cards.innerHTML = "";
        for(let i = user.company.patientCases.length - 1; i >= 0; i--){
            let date = new Date(user.company.patientCases[i].createdAt)
            if(date.getDate() != frstDate.getDate()){
                frstDate = date;
                cards.appendChild(createDateLine(user.company.patientCases[i]));
            }
            cards.appendChild(createCaseCard(user.company.patientCases[i]));
        }
    }
}

if(cards.children.length > 0){
    cards.children[1].dispatchEvent(new Event('click'));
}

searchInput.addEventListener("keyup", () => {
    console.log(searchInput.value);
    searchAllCases();
})

labOptions.addEventListener('change', () => {
    searchAllCases();
})

caseHistoryBtn.addEventListener('click', () => {
    caseInfoBtn.classList.remove('current');
    caseHistoryBtn.classList.add('current');
    const clickedCase = getCase(currentCaseID);
    console.log(clickedCase);
    displayLogs(clickedCase);
})

caseInfoBtn.addEventListener('click', () => {
    displayCurrentCase(currentCaseID);
})

function searchLabCases(){
    let frstDate = new Date(user.company.patientCases[user.company.patientCases.length - 1].createdAt)
    frstDate.setDate(frstDate.getDate() + 1);
    console.log(frstDate);
    cards.innerHTML = "";
    for(let i = user.company.patientCases.length - 1; i >= 0; i--){
        if(user.company.patientCases[i].labID == labOptions.value){
            let date = new Date(user.company.patientCases[i].createdAt)
            console.log(date);
            if(date.getDate() != frstDate.getDate()){
                frstDate = date;
                cards.appendChild(createDateLine(user.company.patientCases[i]));
            }
            cards.appendChild(createCaseCard(user.company.patientCases[i]));
        }
    }
}

function searchAllCases(){
    const sDate = new Date(datePickerStart.value)
    const eDate = new Date(datePickerEnd.value)
    if(labOptions.value == 0 && datePickerStart.value.trim() == "" && datePickerEnd.value.trim() == "" && searchInput.value.trim() == ""){
        loadAllCases()
    }
    else if(labOptions.value != 0 && datePickerStart.value.trim() == "" && datePickerEnd.value.trim() == "" && searchInput.value.trim() == ""){
        searchLabCases();
    }
    else if(labOptions.value == 0 && datePickerStart.value.trim() != "" && datePickerEnd.value.trim() != "" && searchInput.value.trim() == ""){
        searchCasesDate(sDate, eDate);
    }
    else if(labOptions.value != 0 && datePickerStart.value.trim() != "" && datePickerEnd.value.trim() != "" && searchInput.value.trim() == ""){
        searchCasesLabDate(sDate, eDate, labOptions.value);
    }
    else if(labOptions.value == 0 && datePickerStart.value.trim() == "" && datePickerEnd.value.trim() == "" && searchInput.value.trim() != ""){
        searchCasesInput(searchInput.value);
    }
    else if(labOptions.value != 0 && datePickerStart.value.trim() == "" && datePickerEnd.value.trim() == "" && searchInput.value.trim() != ""){
        searchCasesInputLab(searchInput.value, labOptions.value);
    }
    else if(labOptions.value == 0 && datePickerStart.value.trim() != "" && datePickerEnd.value.trim() != "" && searchInput.value.trim() != ""){
        searchCasesInputDate(sDate, eDate, searchInput.value);
    }
    else if(labOptions.value != 0 && datePickerStart.value.trim() != "" && datePickerEnd.value.trim() != "" && searchInput.value.trim() != ""){
        searchCasesInputDateLab(sDate, eDate, searchInput.value, labOptions.value);
    }

    cards.children[1].dispatchEvent(new Event("click"));
}

function searchCasesInputLab(searchValue, labID){
    const sDate = new Date(datePickerStart.value)
    const eDate = new Date(datePickerEnd.value)
    if(datePickerStart.value.trim() == "" || datePickerEnd.value.trim() == ""){
        let frstDate = new Date(user.company.patientCases[user.company.patientCases.length - 1].createdAt)
        frstDate.setDate(frstDate.getDate() + 1);
        console.log(frstDate);
        cards.innerHTML = "";
        for(let i = user.company.patientCases.length - 1; i >= 0; i--){
            if(user.company.patientCases[i].caseName.toLocaleLowerCase().includes(searchValue.toLocaleLowerCase()) &&
            user.company.patientCases[i].labID == labID
            ){
                let date = new Date(user.company.patientCases[i].createdAt)
                console.log(date);
                if(date.getDate() != frstDate.getDate()){
                    frstDate = date;
                    cards.appendChild(createDateLine(user.company.patientCases[i]));
                }
                cards.appendChild(createCaseCard(user.company.patientCases[i]));
            }
        }
    }
    else if(datePickerStart.value < datePickerEnd.value){
        console.log("searching date name")
        searchCasesInputDate(sDate, eDate, searchInput.value);
    }
}

function searchCasesInput(searchValue){
    console.log(datePickerStart.value, datePickerEnd.value);
    const sDate = new Date(datePickerStart.value)
    const eDate = new Date(datePickerEnd.value)
    if(datePickerStart.value.trim() == "" || datePickerEnd.value.trim() == ""){
        let frstDate = new Date(user.company.patientCases[user.company.patientCases.length - 1].createdAt)
        frstDate.setDate(frstDate.getDate() + 1);
        console.log(frstDate);
        cards.innerHTML = "";
        for(let i = user.company.patientCases.length - 1; i >= 0; i--){
            if(user.company.patientCases[i].caseName.toLocaleLowerCase().includes(searchValue.toLocaleLowerCase())){
                let date = new Date(user.company.patientCases[i].createdAt)
                console.log(date);
                if(date.getDate() != frstDate.getDate()){
                    frstDate = date;
                    cards.appendChild(createDateLine(user.company.patientCases[i]));
                }
                cards.appendChild(createCaseCard(user.company.patientCases[i]));
            }
        }
    }
    else if(datePickerStart.value < datePickerEnd.value){
        console.log("searching date name")
        searchCasesInputDate(sDate, eDate, searchInput.value);
    }
}

confirmAddSupplierBtn.addEventListener('click', e => {
    let email = document.getElementById('new-supplier-email').value;
    submitAddNewSupplier(email);
})

addNewSupplierBtns.forEach(btn => {
    btn.addEventListener('click', e => {
        addNewSupplierModal();
    })
})

confirmHoldBtn.addEventListener('click', e => {
    conformHoldBtnClick();
})

holdBtn.addEventListener('click', e => {
    console.log("Hold btn clicked");
    holdBtnClick();
})

confirmDeleteBtn.addEventListener('click', e => {
    deleteSelectedCase();
})

newNote.addEventListener('keypress', e => {
    if(e.keyCode == 13 || e.which == 13){
        if(newNote.value.replace(/\s/g, "").length > 0){
            sendNewCaseMessage();
        }
    }
})

submitNewCaseBtn.addEventListener('click', e => {
    e.preventDefault();
    submitNewCases();
});

closeModalBtns.forEach(btn => {
    btn.addEventListener("click", e => {
        e.preventDefault();
        console.log('clicked')
        const overlay = btn.closest(".overlay");
        overlay.style.display = "none";
    })
})

document.querySelectorAll(".drop-zone__input").forEach(inputElement => {
    const dropZoneElement = inputElement.closest(".drop-zone");

    dropZoneElement.addEventListener("click", e => {
        inputElement.click();
    })

    inputElement.addEventListener('change', e => {
        if(inputElement.files.length){
            if(inputElement.files[0].type == "application/x-zip-compressed"){
                if(user.company.companyTypeID == 1){
                    zipFileUpload(inputElement.files);
                }
                else{
                    caseZipFileUpload(inputElement.files);
                }
            }
            else if(inputElement.files[0].type.startsWith("image/")){
                imageFileUpload(inputElement.files);
            }
            else{
                alert("Unexpected file types");
            }
        }
    })

    dropZoneElement.addEventListener("dragover", e => {
        e.preventDefault();
        dropZoneElement.classList.add("drop-zone--over");
    })

    dropZoneElement.addEventListener("dragleave", e => {
        dropZoneElement.classList.remove("drop-zone--over");
    })

    dropZoneElement.addEventListener("dragend", e => {
        dropZoneElement.classList.remove("drop-zone--over");
    })

    dropZoneElement.addEventListener("drop", e => {
        e.preventDefault();
        dropZoneElement.classList.remove("drop-zone--over");
        if(e.dataTransfer.files.length){
            inputElement.files = e.dataTransfer.files;
            if(inputElement.files[0].type == "application/x-zip-compressed"){
                if(user.company.companyTypeID == 1){
                    zipFileUpload(inputElement.files);
                }
                else{
                    caseZipFileUpload(inputElement.files);
                }
            }
            else if(inputElement.files[0].type.startsWith("image/")){
                imageFileUpload(inputElement.files);
            }
            else{
                alert("Unexpected file type");
            }
        }
    })
})

function submitAddNewSupplier(email){
    $.ajax({
        type: "Post",
        url: "/Home/SubmitNewSupplier",
        dataType: "json",
        data: {email: email},
        success: function (response) {
            if(response.message == 'Not logged in!'){
                window.location.reload(true);
            }
            processNewSuplierSuccessResponse(response);
        },
        error: function () {
            alert("Your case did not save correctly, if the problem persists please contact administration.");
        }
    });
}

function processNewSuplierSuccessResponse(response){
    
    if(response.message.companyFriend != undefined){
        const friend = response.message.companyFriend;
        user.company.friends.push(friend);
        const labSelects = document.querySelectorAll('.new-case-lab');
        labSelects.forEach(select => {
            select.removeChild(select.children[select.children.length-1]);
            let htmlString = `
                <option selected value="${friend.companyID}">${friend.companyName}</option>
                <option value='null'>Assign Later</option></select>
            `
            select.innerHTML += htmlString;
        })        
    }
    else if(response.message == "Thank you for adding another supplier. Once they register their account they will be added as a supplier for you."){
        alert(response.message);
    }
}

function newImageLoad(image){
    addCaseFile(image);
    document.getElementById(`patient-case-${image.patientCaseID}`).dispatchEvent(new Event('click'));
}

function addCaseFile(caseFile){
    for(let i = 0; i < user.company.patientCases.length; i++){
        if(user.company.patientCases[i].patientCaseID == caseFile.patientCaseID){
            if(user.company.patientCases[i].uploadFiles == null){
                user.company.patientCases[i].uploadFiles = [];
            };
            user.company.patientCases[i].uploadFiles.push(caseFile);
            break;
        }
    }
}

function processDBNote(message){
    for(let i = 0; i < user.company.patientCases.length; i++){
        if(user.company.patientCases[i].patientCaseID == message.patientCaseID){
            if(user.company.patientCases[i].caseNotes == null){
                user.company.patientCases[i].caseNotes = [];
            };
            user.company.patientCases[i].caseNotes.push(message);
            break;
        }
    }
    const msgCard = createNewMsgCard(message, "my-note", "designer");
    const notes = document.getElementById('notes');
    notes.appendChild(msgCard);
    newNote.value = "";
    newNote.focus();
}

function displayNotes(clickedCase){
    const notes = document.getElementById('notes');
    notes.innerHTML = "";
    for(let i = 0; i < clickedCase.caseNotes.length; i++){
        let msgCard;
        if(clickedCase.caseNotes[i].companyID == user.companyID){
            msgCard = createNewMsgCard(clickedCase.caseNotes[i], "my-note", "designer")
        }
        else{
            msgCard = createNewMsgCard(clickedCase.caseNotes[i], "their-note", "doc")
        }
        notes.appendChild(msgCard);
    }
    notes.scrollTop = notes.scrollHeight;
}

function createNewMsgCard(message, noteType, myTheir){
    const newMsgCard = document.createElement('div');
    newMsgCard.classList.add('note-card');    
    newMsgCard.classList.add(myTheir);
    let cardString = `
        <div class="${noteType}">
            <h4>${message.senderName}</h4>
            <div class="note-body">
    `;
    if(user.company.companyTypeID == 1){
        if(noteType == "their-note"){
            cardString += `
                <p class="note">${message.noteText}</p>
                <i class="fa fa-user${message.companyTypeID == 1 ? "-md" : ""}" aria-hidden="true"></i>
            `;            
        }
        else if(noteType == "my-note"){
            cardString += `
            <i class="fa fa-user${message.companyTypeID == 1 ? "-md" : ""}" aria-hidden="true"></i>
            <p class="note">${message.noteText}</p>
            `;
        }
    }
    else{
        if(noteType == "their-note"){
            cardString += `
                <p class="note">${message.noteText}</p>
                <i class="fa fa-user${message.companyTypeID == 1 ? "-md" : ""}" aria-hidden="true"></i>
            `;            
        }
        else if(noteType == "my-note"){
            cardString += `
                <i class="fa fa-user${message.companyTypeID == 1 ? "-md" : ""}" aria-hidden="true"></i>
                <p class="note">${message.noteText}</p>
            `;
        }
    }
    cardString += "</div></div>";

    newMsgCard.innerHTML = cardString;
    return newMsgCard;
}

function sendNewCaseMessage(){
    var data = new FormData;
    data.append("NoteText", newNote.value);
    data.append("PatientCaseID", currentCaseID);
    $.ajax({
        type: "Post",
        url: "/Home/SubmitNewCaseMessage",
        data: data,
        contentType: false,
        processData: false,
        success: function (response) {
            if(response.message == 'Not logged in!'){
                window.location.reload(true);
            }
            processDBNote(response.message);
        },
        error: function () {
            alert("Your file did not load successfully. Please check your internet connection and try again.");
        }
    });
}

function imageFileUpload(files){
    var data = new FormData();
    data.append("caseID", currentCaseID);
    for(let i = 0; i < files.length; i++){
        data.append(files[i].name, files[i]);
    }
    $.ajax({
        type: "Post",
        url: "/Home/ZipFilesUpload",
        data: data,
        contentType: false,
        processData: false,
        success: function (response) {
            if(response.message == 'Not logged in!'){
                window.location.reload(true);
            }
            for(let i = 0; i < response.message.length; i++){
                let image = response.message[i];
                newImageLoad(image);
            }
        },
        error: function () {
            alert("Your file did not load successfully. Please check your internet connection and try again.");
        }
    });
}

function caseZipFileUpload(files) {
    var data = new FormData();
    for(let i = 0; i < files.length; i++){
        data.append(files[i].name, files[i]);
    }
    // data.append("UploadFileName", file.name);
    $.ajax({
        type: "Post",
        url: "/Home/CaseZipFilesUpload",
        data: data,
        contentType: false,
        processData: false,
        success: function (response) {
            if(response.message == 'Not logged in!'){
                window.location.reload(true);
            }
            loadCaseLogs(response.message);
        },
        error: function () {
            alert("Your file did not load successfully. Please check your internet connection and try again.");
        }
    });
}

function loadCaseLogs(logs){
    for(let i = 0; i < logs.length; i++){
        logs[i].actionName = `${user.firstName} ${user.lastName}`;
        const pCase = getCase(logs[i].patientCaseID);
        pCase.caseLogs.push(logs[i]);
        const caseCard = document.getElementById(`patient-case-${logs[i].patientCaseID}`)
        caseCard.querySelector(".circle").classList = "circle circle-green";
    }
}

function zipFileUpload(files) {
    var data = new FormData();
    for(let i = 0; i < files.length; i++){
        data.append(files[i].name, files[i]);
    }
    // data.append("UploadFileName", file.name);
    $.ajax({
        type: "Post",
        url: "/Home/ZipFilesUpload",
        data: data,
        contentType: false,
        processData: false,
        success: function (response) {
            if(response.message == 'Not logged in!'){
                window.location.reload(true);
            }
            newCasesModal(response.message);            
        },
        error: function () {
            alert("Your file did not load successfully. Please check your internet connection and try again.");
        }
    });
}

class UploadFileList{
    constructor(list){
        this.UploadFiles = list;
    }
}

class UploadFile{
    constructor(uf, name, id = null){
        this.UploadFileFile = uf;
        this.UploadFileName = name;
        this.UploadFileID = id;
    }
}

class PatientCase{
    constructor(name, labID, UFID){
        this.CaseName = name;
        this.LabID = labID;
        this.CasePhaseID = UFID;
    }
}

function submitNewCases(){
    const caseNames = document.querySelectorAll(".new-case-name");
    const caseLabs = document.querySelectorAll(".new-case-lab");
    const cases = [];
    for(let i = 0; i < caseNames.length; i++){
        const patientCase = new PatientCase(caseNames[i].value, parseInt(caseLabs[i].value), parseInt(caseNames[i].id.substring(23)));
        cases.push(patientCase);
    }
    console.log("calling");
    $.ajax({
        type: "Post",
        url: "/Home/SubmitNewDBCases",
        dataType: "json",
        data: {Cases: cases},
        success: function (response) {
            if(response.message == 'Not logged in!'){
                window.location.reload(true);
            }
            window.location.reload(true);
            let patientCases = response.message;
            loadNewSavedCases(patientCases);
            document.getElementById('case-creator-close-x').dispatchEvent(new Event('click'));
            patientCases.forEach(patientCase => {
                user.company.patientCases.push(patientCase);
            })
        },
        error: function () {
            alert("Your case did not save correctly, if the problem persists please contact administration.");
        }
    });
}

function addNewSupplierModal(){
    const addSupplierModal = document.getElementById("add-new-supplier-modal");
    const closeModalBtns = document.querySelectorAll('.close-x');
    addSupplierModal.style.display = 'flex';
}

function newCasesModal(files){
    const newCaseModal = document.getElementById("new-case-modal");
    const newCasesBox = document.getElementById("new-cases-data-points");
    files.forEach(file => {
        newCasesBox.appendChild(createNewCaseDataPoint(file))
    })
    newCaseModal.style.display = 'flex';
}

function createNewCaseDataPoint(file){
    const dataPoint = document.createElement('div');
    dataPoint.classList.add('data-point');
    let htmlString = `
        <label for="">Name:</label>
        <input type="text" class="new-case-name" value="${file.uploadFileName.substring(0, file.uploadFileName.length - 4)}" id="case-creator-case-name-${file.uploadFileID}" placeholder="Case Name">
        <select class="new-case-lab" id="case-creator-lab-select-${file.uploadFileID}">
    `;

    for(let i = 0; i < user.company.friends.length; i++){
        if(selectedLab == user.company.friends[i].companyID){
            htmlString += `
                <option selected value="${user.company.friends[i].companyID}">${user.company.friends[i].companyName}</option>
            `;
        }
        else{
            htmlString += `
                <option value="${user.company.friends[i].companyID}">${user.company.friends[i].companyName}</option>
            `;
        }
    }

    htmlString += "<option value='null'>Assign Later</option></select>";

    dataPoint.innerHTML = htmlString;
    return dataPoint;
}

function loadNewSavedCases(patientCases){
    patientCases.forEach(patientCase => {
        const newCard = createCaseCard(patientCase);
        cards.appendChild(newCard);
    })
}

function patientCardClick(cardID){
    currentCaseID = cardID.substring(13);
    const currentCard = cards.querySelectorAll(".current");
    if(currentCard.length > 0){
        currentCard[0].classList.remove('current');
    }
    const card = document.getElementById(cardID);
    card.classList.add("current");
    displayCurrentCase(currentCaseID);
}

function displayCurrentCase(caseID){
    caseInfoBtn.classList.add('current');
    caseHistoryBtn.classList.remove('current');
    for(let i = 0; i < user.company.patientCases.length; i++){
        if(user.company.patientCases[i].patientCaseID == caseID){
            document.getElementById("current-case-name").innerText = user.company.patientCases[i].caseName;
            let createDate = user.company.patientCases[i].createdAt.substring(0, 10);
            document.getElementById("current-case-date").innerText = createDate;
            document.getElementById("current-case-designer").innerText = getCaseDesignerName(currentCaseID);
            displayImages(user.company.patientCases[i]);
            displayNotes(user.company.patientCases[i]);
            highlightHold(user.company.patientCases[i]);
            break;
        }
    }
}

function getCaseDesignerName(caseID){
    console.log(currentCaseID);
    const currentCase = getCase(caseID);
    console.log(currentCase);
    if(user.company.companyTypeID == 1){
        console.log(user.company.friends)
        for(let i = 0; i < user.company.friends.length; i++){
            console.log(user.company.friends[i].companyID, currentCase.labID)
            if(user.company.friends[i].companyID == currentCase.labID){
                console.log(user.company.friends[i].companyName);
                return user.company.friends[i].companyName;
            }
        }
    }
    else if(user.company.companyTypeID == 2){
        console.log(user.company.friends)
        for(let i = 0; i < user.company.friends.length; i++){
            console.log(user.company.friends[i].companyID, currentCase.companyID)
            if(user.company.friends[i].companyID == currentCase.companyID){
                console.log(user.company.friends[i].companyName);
                return user.company.friends[i].companyName;
            }
        }
    }
    return "Hello";
}

function highlightHold(clickedCase){
    const redSections = document.querySelectorAll(".hold-border-identifier");
    const holdHeader = document.getElementById('hold-header');
    const holdEx = document.getElementById('hold-explanation');
    const caseCard = cards.querySelector(`#patient-case-${clickedCase.patientCaseID}`);
    const circle = caseCard.querySelector('.circle');
    if(!clickedCase.hold){
        redSections.forEach(section => {
            section.classList.remove('hold-border');
        })
        holdBtn.innerText = "HOLD";
        holdBtn.style.color = 'red';
        holdHeader.innerText = "Confirm Hold";
        holdEx.innerText = "place a hold";
        circle.classList = `circle circle-${getCircleColor(clickedCase)}`;
    }
    else{
        redSections.forEach(section => {
            section.classList.add('hold-border');
        })
        holdBtn.innerText = "REMOVE HOLD";
        holdBtn.style.color = 'green';
        holdHeader.innerText = "Remove Hold";
        holdEx.innerText = "remove the hold";
        circle.classList = "circle circle-red";
    }

}

function displayLogs(clickedCase){
    const displayImageBox = document.getElementById('display-image-box');
    displayImageBox.innerHTML = "";
    const ulEl = document.createElement('ul');
    if(clickedCase.caseLogs){
        for(let i = 0; i < clickedCase.caseLogs.length; i++){
            const liEl = document.createElement('li');
            liEl.innerText = `
                ${clickedCase.caseLogs[i].actionName} ${clickedCase.caseLogs[i].message}
            `;
            ulEl.appendChild(liEl);
        }
        displayImageBox.appendChild(ulEl);
    }
}

function displayImages(clickedCase){
    const imagesBox = document.getElementById('other-images');
    const displayImageBox = document.getElementById('display-image-box');
    imagesBox.innerHTML = "";
    displayImageBox.innerHTML = "";
    for(let i = clickedCase.uploadFiles.length - 1; i >= 0 ; i--){
        if(clickedCase.uploadFiles[i].fileTypeID == 1){
            const imageBox = document.createElement('div');
            imageBox.classList.add("image-box")
            const caseImage = document.createElement('img');
            caseImage.src = clickedCase.uploadFiles[i].uploadFilePath;
            caseImage.addEventListener('click', e => {
                displayClickedImage(caseImage.src);
            })
            imageBox.appendChild(caseImage);
            imagesBox.appendChild(imageBox);
        }
    }
    if(imagesBox.children.length > 0){
        imagesBox.children[0].querySelector("img").dispatchEvent(new Event('click'));
    }
}

function displayClickedImage(imageSRC){
    const displayImage = document.getElementById('displayed-image')
    if(displayImage == null){
        const displayImageBox = document.getElementById('display-image-box');
        displayImageBox.innerHTML = `<img src="${imageSRC}" alt="" id="displayed-image">`
    }
    else{
        displayImage.src = imageSRC;
    }
}

function getCircleColor(patientCase){
    let circleColor = "";
    if(patientCase.hold){
        circleColor += "red";
    }
    else if(patientCase.casePhaseID == 1){
        circleColor += "gray";
    }
    else if(patientCase.casePhaseID == 2){
        circleColor += "blue";
    }
    else if(patientCase.casePhaseID == 3){
        circleColor += "yellow";
    }
    else if(patientCase.casePhaseID == 4){
        circleColor += "green";
    }
    return circleColor;
}


function createDateLine(patientCase){
    const dateLineEl = document.createElement('div');
    dateLineEl.classList = 'date-line';
    let date = patientCase.createdAt;
    date = new Date(date);
    console.log(date.toDateString());
    dateLineEl.innerHTML = `
        <div class="line"></div>
        <span class="date">${date.toDateString()}</span>
    `;
    return dateLineEl;
}

function createCaseCard(patientCase){
    console.log(patientCase);
    let idx = 0;
    for(let i = 0; i < patientCase.uploadFiles.length; i++){
        if(patientCase.uploadFiles[i].uploadFilePath.substring(patientCase.uploadFiles[i].uploadFilePath.length - 4) == ".zip"){
            idx = i;
        }
    }
    let zipPath = `Home/SubmitDownloadFile/?filePath=${patientCase.uploadFiles[idx].uploadFilePath}`;
    let patientCard = document.createElement('div');
    patientCard.classList.add("card");
    patientCard.id = `patient-case-${patientCase.patientCaseID}`;
    let circleColor = `circle-${getCircleColor(patientCase)}`;
    let newPCNote = newPatientCaseNote(patientCase);
    patientCard.innerHTML = `
        <div class="left-side">
            <div class="circle ${circleColor}"></div>
            <i class="fa fa-address-card" aria-hidden="true"></i>
            <b>${patientCase.caseName}</b>
        </div>
        <div class="icons">
            <i class="fa ${newPCNote ? "fa-envelope" : ""}" aria-hidden="true"></i>
            <a href="${zipPath}"><i class="fa fa-download" aria-hidden="true"></i></a>
            <i class="fa fa-upload" aria-hidden="true"></i>
            <i class="fa fa-sync" aria-hidden="true"></i>
            <i class="fa fa-times" aria-hidden="true"></i>
        </div>
    `;

    patientCard = addPatientCardELs(patientCard);

    return patientCard;
}

function newPatientCaseNote(patientCase){
    for(let i = 0; i < patientCase.caseNotes.length; i++){
        if(patientCase.caseNotes[i].companyID != user.company.companyID){
            if(!patientCase.caseNotes[i].noteRead){
                return true;
            }
        }
    }
    return false;
}

function addPatientCardELs(patientCard){
    patientCard.addEventListener('click', e => {
        patientCardClick(patientCard.id);
    })
    const circle = patientCard.querySelector('.circle');
    if(circle){
        circle.addEventListener('click', e => {
            console.log("Circles!");
            circleBtnClick(patientCard.id)
        })
    }
    const envelopeBtn = patientCard.querySelector('.fa-envelope');
    if(envelopeBtn){
        envelopeBtn.addEventListener('click', e => {
            console.log("New Message!");
            caseEnvelopBtnClick(patientCard.id)
        })
    }
    const downloadBtn = patientCard.querySelector('.fa-download');
    if(downloadBtn){
        downloadBtn.addEventListener('click', e => {
            console.log("Downloading!");
            caseDownloadBtnClick(patientCard.id)
        })
    }
    const uploadBtn = patientCard.querySelector('.fa-upload');
    if(uploadBtn){
        uploadBtn.addEventListener('click', e => {
            console.log("Uploading!");
            caseUploadBtnClick(patientCard.id);
        })
    }
    const syncBtn = patientCard.querySelector('.fa-sync');
    if(syncBtn){
        syncBtn.addEventListener('click', e => {
            console.log("Synchronizing!");
            caseSyncBtnClick(patientCard.id)
        })
    }
    const timesBtn = patientCard.querySelector('.fa-times');
    if(timesBtn){
        timesBtn.addEventListener('click', e => {
            console.log("Deleting");
            caseDeleteBtnClick(patientCard.id);
        })
    }

    return patientCard;
}

function circleBtnClick(caseID){
    caseID = caseID.substring(13);
    console.log(caseID);
}

function caseEnvelopBtnClick(caseID){
    caseID = caseID.substring(13);
    console.log(caseID);
    $.ajax({
        type: "Post",
        url: "/Home/SubmitCaseNoteRead",
        dataType: "json",
        data: {caseID: caseID},
        success: function (response) {
            if(response.message == 'Not logged in!'){
                window.location.reload(true);
            }
            else if(response.message == "Success!"){
                removeEnvelope(caseID);
            }
        },
        error: function () {
            alert("Your case did not save correctly, if the problem persists please contact administration.");
        }
    });
}

function removeEnvelope(caseID){
    const patientCard = document.getElementById(`patient-case-${caseID}`);
    const envEL = patientCard.querySelector('.fa-envelope');
    envEL.classList.remove('fa-envelope');
    envEL.replaceWith(envEL.cloneNode(true));
    const notes = document.getElementById('notes');
    notes.scrollTop = notes.scrollHeight;
}

function caseDownloadBtnClick(caseID){
    caseID = caseID.substring(13);
    const patientCase = getCase(caseID);
    if(user.companyID != patientCase.companyID){
        patientCase.casePhaseID = 3;
    }
}

function caseUploadBtnClick(caseID){
    caseID = +caseID.substring(13);
    $.ajax({
        type: "Post",
        url: "/Home/SubmitUploadCase",
        dataType: "json",
        data: {caseID: caseID},
        success: function (response) {
            if(response.message == 'Not logged in!'){
                window.location.reload(true);
            }
            processSubmitUploadCaseResponse(response);
        },
        error: function () {
            alert("Your case did not save correctly, if the problem persists please contact administration.");
        }
    });
}

function processSubmitUploadCaseResponse(response){
    console.log(response);
    if(response.message){
        for(let i = 0; i < user.company.patientCases.length; i++){
            if(user.company.patientCases[i].patientCaseID == response.message){
                user.company.patientCases[i] = response.message;
                break;
            }
        }
        const caseCard = document.getElementById(`patient-case-${response.message}`);
        const indicatorLight = caseCard.querySelector('.circle');
        indicatorLight.classList = 'circle circle-blue';
    }
}

function caseSyncBtnClick(caseID){
    caseID = caseID.substring(13);
    console.log(caseID);
}


function holdBtnClick(){
    const currentCase = getCase(currentCaseID);
    const caseNameContainer = document.getElementById('confirm-hold-case-name');
    caseNameContainer.innerText = currentCase.caseName;
    const caseHoldModal = document.getElementById('confirm-hold-case-modal');
    caseHoldModal.style.display = 'flex';    
}

function conformHoldBtnClick(){
    const caseHoldModal = document.getElementById('confirm-hold-case-modal');
    caseHoldModal.style.display = 'none';
    var data = new FormData;
    data.append("PatientCaseID", currentCaseID);
    $.ajax({
        type: "Post",
        url: "/Home/SubmitHoldCase",
        data: data,
        contentType: false,
        processData: false,
        success: function (response) {
            if(response.message == 'Not logged in!'){
                window.location.reload(true);
            }
            processHoldSuccess(currentCaseID);
        },
        error: function () {
            alert("Unable to delete case, if the problem persists please contact administration.");
        }
    });
}

function processHoldSuccess(currentCaseID){
    const currentCase = getCase(currentCaseID);
    if(currentCase.hold){
        currentCase.hold = false;
    }
    else{
        currentCase.hold = true;
    }
    highlightHold(currentCase);
    const holdNote = document.getElementById('new-hold-note');
    newNote.value = holdNote.value;
    holdNote.value = "";
    if(newNote.value.replace(/\s/g, "").length > 0){
        sendNewCaseMessage();
    }
}

function caseDeleteBtnClick(caseID){
    caseID = caseID.substring(13);
    const currentCase = getCase(caseID);
    const caseNameContainer = document.getElementById('confirm-delete-case-name');
    caseNameContainer.innerText = currentCase.caseName;
    const caseDeleteModal = document.getElementById('confirm-delete-case-modal');
    caseDeleteModal.style.display = 'flex';

}

function deleteSelectedCase(){
    submitDeleteCase();
    const caseDeleteModal = document.getElementById('confirm-delete-case-modal');
    caseDeleteModal.style.display = 'none';    
}

function submitDeleteCase(){
    var data = new FormData;
    data.append("PatientCaseID", currentCaseID);
    $.ajax({
        type: "Post",
        url: "/Home/SubmitDeleteCase",
        data: data,
        contentType: false,
        processData: false,
        success: function (response) {
            if(response.message == 'Not logged in!'){
                window.location.reload(true);
            }
            const deleteCard = document.getElementById(`patient-case-${currentCaseID}`);
            deleteCard.remove();
            cards.children[1].dispatchEvent(new Event("click"));
        },
        error: function () {
            alert("Unable to delete case, if the problem persists please contact administration.");
        }
    });
}

function getCase(caseID){
    for(let i = 0; i < user.company.patientCases.length; i++){
        if(user.company.patientCases[i].patientCaseID == caseID){
            return user.company.patientCases[i];
        }
    }
}