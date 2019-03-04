var express = require('express'),
  app = express(),
  server = require('http').createServer(app),
  io = require('socket.io').listen(server);

server.listen(9001); 

io.on('connection', function (socket) {   

    socket.on('disconnect', function (data) {  
    	console.log("Disconnect:", data.name);
        socket.emit('response', { playerName: data.name });
    }); 

    socket.on('login', function (data) {  
    	console.log("Login:", data.name); 
        socket.emit('response', { playerName: data.name });
    }); 
});