"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/buttonCounterHub").build();

//Disable button until connection is established
document.getElementById("incrementButton").disabled = true;

connection.on("ReceiveCount", function (count) {
    document.getElementById("countText").innerHTML = "" + count;
});

connection.start().then(function(){
    document.getElementById("incrementButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("incrementButton").addEventListener("click", function (event) {
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/increment", true);
    xhr.send();
    
    event.preventDefault();
});
