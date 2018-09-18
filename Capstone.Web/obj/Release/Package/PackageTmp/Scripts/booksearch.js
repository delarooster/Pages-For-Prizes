$("#Title").blur(function () {
    let title = document.getElementById('Title').value;
    //let author = document.getElementById('Author').value;
    document.getElementById('ISBN').innerHTML = "";
    console.log(title);
    //console.log(author);

    $.ajax({
        url: "https://www.googleapis.com/books/v1/volumes?q=" + title + "&maxResults=1",
        dataType: "json",

        success: function (data) {
            let author = data.items[0].volumeInfo.authors[0];
            let ISBN = data.items[0].volumeInfo.industryIdentifiers[0].identifier;
            //passing JSON ISBN data to ISBN field
            displayISBN(ISBN);
            //passing JSON author data to Author field
            displayAuthor(author);
        },

        type: 'GET'

    });
});
function displayISBN(num) {
    console.log(num);
    $("#ISBN").val(num);
}
function displayAuthor(name) {
    console.log(name);
    $("#Author").val(name);
}
