console.log('Server application running...');

var app = require('express')();
var http = require('http').createServer(app);
var io = require('socket.io')(http);
var _ = require('underscore');

var EVENTS = {
    CONNECTION: 'connection',
    DISCONNECT: 'disconnect',
    CLIPBOARD_CHANGE: 'clipboard_change',
    ALL_CLIPBOARDS: 'all_clipboards',
    GET_CLIPBOARD_BY_ID: 'get_clipboard_by_id',
    GET_ALL_CLIPBOARDS: 'get_all_clipboards'
}

var clipboard = {}

http.listen(3000, function () {
    console.log('listening on *:3000');
});

var isNotEmpty = function (object) {
    return object !== undefined && object !== null && object !== '';
}

io.on(EVENTS.CONNECTION, function (socket) {
    console.log('New user connected');
    
    socket.on(EVENTS.CLIPBOARD_CHANGE, function (data) {
        var clipboardData = JSON.parse(data);
        if (isNotEmpty(clipboardData.Id) && isNotEmpty(clipboardData.Sender) && isNotEmpty(clipboardData.Type) && isNotEmpty(clipboardData.Data)) {
            console.log('Clipboard changed:\n    Id: ' + clipboardData.Id + '\n    Sender: ' + clipboardData.Sender + '\n    Type: ' + clipboardData.Type);
            clipboard[clipboardData.Id] = clipboardData;
            //socket.broadcast.emit(EVENTS.CLIPBOARD_CHANGE, clipboardData);  //sends to all without sender
            io.sockets.emit(EVENTS.CLIPBOARD_CHANGE, clipboardData);  //sends to all including sender
        } else {
            console.log('Clipboard changed, but with incomplete data\n    Id: ' + clipboardData.Id + '\n    Sender: ' + clipboardData.Sender + '\n    Type: ' + clipboardData.Type + '\n    Data: ' + clipboardData.Data);
        }
    });
    
    socket.on(EVENTS.GET_CLIPBOARD_BY_ID, function (id) {
        console.log('got request for clipboard: ' + id);
        var requestedClipboard = clipboard[id];
        if (isNotEmpty(clipboard)) {
            socket.emit(EVENTS.CLIPBOARD_CHANGE, requestedClipboard);
        }
    });
    
    socket.on(EVENTS.GET_ALL_CLIPBOARDS, function () {
        socket.emit(EVENTS.ALL_CLIPBOARDS, _.values(clipboard));
    });
    
    socket.on(EVENTS.DISCONNECT, function () {
        console.log('User disconnected');
    });
});
