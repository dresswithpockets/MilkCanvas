const express = require('express');
const path = require('path');
const fs = require('fs');
const app = express();

return function (port, cb) {

    app.get('/twitch', function (req, res) {
        // should AJAX to /twitch/authenticate? + window.location.hash.substring(1, window.location.hash.length)
        res.sendFile(path.join(__dirname, "..", "Pages", "twitch.html"));
    });

    app.get('/twitch/authenticate', function (req, res) {
        fs.writeFile('hash', JSON.stringify(req.query), function (err) {
            if (err) {
                return console.log(err);
            }
        });
        res.send("done");
    });

    app.listen({ port: port }, () => { });

    cb();
};