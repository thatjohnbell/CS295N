// const BOOK_URL = "http://localhost:64949/api/books";
const BOOK_URL = "http://BookCatalog20171113125732.azurewebsites.net/api/books";

/***********************************************************/
/************* Get all books from the database ************/
/***********************************************************/

function getAllBooks(onloadHandler) {
    var xhr = new XMLHttpRequest();
    xhr.onload = onloadHandler;
    xhr.onerror = errorHandler;
    xhr.open("GET", BOOK_URL, true);
    xhr.send();
}

// Loop through the books and put them in the table
function fillTable() {
    var books = JSON.parse(this.responseText);
    for (var i in books) {
        addRow(books[i]);
    }
}

// Put info for one book in a table row
function addRow(book) {
    var tbody = document.getElementsByTagName('tbody')[0];
    var fields = ["title", "author", "publisher", "datePublished", "rating", "rater"];
    var tr = document.createElement('tr');
    // Add a cell with the value from each field
    for (var i in fields) {
        var td = document.createElement('td');
        var field = fields[i];
        if (field === "datePublished") {
            td.innerHTML = book[field].substr(0, 10);
        } else {
            td.innerHTML = book[field];
        }
        tr.appendChild(td);
    }
    tbody.appendChild(tr);
}

function errorHandler(e) {
    window.alert("book API request failed.");
}

/***********************************************************/
/**************** Add a book to the database **************/
/***********************************************************/

// Generate a book object from the HTML form data
function getFormData() {
    // collect the form data by iterating over the input elements
    var data = {};
    var form = document.getElementById('bookForm');
    for (var i = 0; i < form.length; ++i) {
        var input = form[i];
        if (input.name) {
            data[input.name] = input.value;
        }
    }
    return data;
}

// Send a new book object to the database
function addBook() {
    var data = getFormData();


    // create an HTTP POST request
    var xhr = new XMLHttpRequest();
    // Parameters: request type, URL, async (if false, send does not return until a response is recieved)
    xhr.open("POST", BOOK_URL, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onerror = errorHandler;
    xhr.onreadystatechange = function() {
    };
    // serialize the data to a string so it can be sent
    var dataString = JSON.stringify(data);
    xhr.send(dataString);
    addRow(data);
}

/***********************************************************/
/********* Update a book already in the database **********/
/***********************************************************/

// Fill the select (drop down list) with book titles
// Called by getAllBooks which is called by the page load event
function fillSelectList() {
    var books = JSON.parse(this.responseText);
    var sel = document.getElementsByTagName('select')[0];
    for (var i in books) {
        var opt = document.createElement("option");
        opt.setAttribute("value", books[i].id);
        opt.innerHTML = books[i].title;
        sel.appendChild(opt);
    }
}

function clearSelectList() {
    var select = document.getElementsByTagName("select")[0];
    var length = select.options.length;
    // remove all but the first option element
    for (i = 1; i < length; i++) {
        select.options[i] = null;
    }
}

// get one book by it's ID
// onloadHandler will be fillForm()
// Called when a book is selected from the select list
function getBookById(event) {
    var xhr = new XMLHttpRequest();
    xhr.onload = fillForm;
    xhr.onerror = errorHandler;
    xhr.open("GET", BOOK_URL + "/" + event.target.value, true);
    xhr.send();
}

// puts data from existing book into the form 
// called back by getbookById
function fillForm() {
    var book = JSON.parse(this.responseText);
    var inputs = document.getElementsByTagName("input");
    inputs[0].value = book.id;
    inputs[1].value = book.title;
    inputs[2].value = book.author;
    inputs[3].value = book.publisher;
    inputs[4].value = book.datePublished.substr(0, 10); // just the date, not the time
    inputs[5].value = book.rating;
    inputs[6].value = book.rater;
}

// Send new data for an existing book to the database
function updateBook() {
    var data = getFormData();

    // create an HTTP PUT request
    var xhr = new XMLHttpRequest();
    xhr.open("PUT", BOOK_URL + "/" + data.id, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onerror = errorHandler;

    // serialize the data to a string so it can be sent
    var dataString = JSON.stringify(data);
    xhr.send(dataString);
    clearSelectList();
}

/**************************************************/
/******************** Delete a book **************/
/**************************************************/

// Remove a book from the database
function deleteBook() {
    var data = getFormData();
    var xhr = new XMLHttpRequest();
    xhr.open("DELETE", BOOK_URL + "/" + data.id, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.onerror = errorHandler;
    xhr.onreadystatechange = function () {
        // if readyState is "done" and status is "success"
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 204) {
            clearSelectList();
            getAllBooks(fillSelectList);
        }
    };
    xhr.send();
}