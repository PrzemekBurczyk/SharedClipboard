console.log('Server application running...');

var app = require('express')();
var http = require('http').createServer(app);
var io = require('socket.io')(http);

http.listen(3000, function () {
    console.log('listening on *:3000');
}); 

io.on('connection', function (socket) {
    console.log('New user connected');
    
    socket.emit('hi', 'data');
    
    socket.on('hi', function (data) {
        console.log(data);
    });

    socket.on('disconnect', function () {
        console.log('User disconnected');
    });
});

//app.get('/', function (req, res) { 
//    res.sendfile('index.html'); 
//}); 

