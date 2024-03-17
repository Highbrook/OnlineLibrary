async function createApiCall(userInput) {
    const volumeAppendPrefix = 'https://www.googleapis.com/books/v1/volumes?q=';
    var query = "";
    if (userInput != null && userInput != undefined) {
        query = userInput.split(' ').join('+');
    } else {
        query = "";
    }
    const pagination = '&maxResults=40'
    const volumeQuery = volumeAppendPrefix + query + pagination;

    httpRequest = new XMLHttpRequest();

    if (!httpRequest) {
        alert('Cannot create an XMLHTTP instance');
        return false;
    }
    httpRequest.onreadystatechange = await alertContents;

    //open() use interpolation to put user query into URL for request
    httpRequest.open('GET', volumeQuery, true);

    //send() request
    httpRequest.send(null);
}


async function alertContents() {
    //check if request processed.
    if (httpRequest.readyState === XMLHttpRequest.DONE) {

        //check response wasnt 500 or 404 error
        if (httpRequest.status === 200) {

            //put response into var called obj
            var obj = httpRequest.response;
            //turn obj into JSON data
            var parsed = JSON.parse(obj);
            var stringified = JSON.stringify(parsed);

            //loop through parsed object
            for (i = 0; i < parsed.items.length; i++) {

                var ul = document.getElementById('books');
                //create li nodes and set their inner HTML to be titles of books returned from API
                var li = document.createElement('li');
                li.innerHTML = "<strong>" + "Title: " + "</strong>" + parsed.items[i].volumeInfo.title;
                ul.appendChild(li);
            }

            //send JSON data to BrowseBooksController
            $.ajax({
                method: 'post',
                url:'Browse',
                //contentType: 'application/json; charset=utf-8',
                dataType: 'text',
                async: false,
                data: JSON.stringify(obj),
                success: function (data) {
                    console.log("Successfully passed JSON to Controller: " + data);
                },
                error: function (data) {
                    alert('error');
                    console.log(data);
                }
            });

        } else {
            console.log('There was a problem with the request.');
        }
    }
}




