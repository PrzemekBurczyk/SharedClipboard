console.log('Server application running...');

var app = require('express')();
var http = require('http').createServer(app);
var io = require('socket.io')(http);

var clipboardSize = 5;
var clipboard = {}

for (var i = 1; i <= clipboardSize; i++) {
	clipboard[i] = {
				"type": "",
				"value": ""
			};
}

http.listen(3000, function () {
    console.log('listening on *:3000');
}); 

io.on('connection', function (socket) {
    console.log('New user connected');
    
    socket.emit('hi', 'data');
    
    socket.on('hi', function (data) {
        console.log(data);
    });
	
	socket.on('text', function(data) {
		console.log('received: ' + data);
		clipboard[0].type = "text";
		clipboard[0].value = data;
	});
	
	socket.on('demand', function(data) {
		if (data <= clipboardSize && data > 0) {
			console.log('sending: ' + textData);
			socket.emit('text', clipboard[data].value);
		}
	});

    socket.on('disconnect', function () {
        console.log('User disconnected');
    });
});

//app.get('/', function (req, res) { 
//    res.sendfile('index.html'); 
//}); 

