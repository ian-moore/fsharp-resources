var path = require('path'),
    fs = require('fs');

fs.readdir('./content/', function(err, files) {
    files.forEach(function(f, i) {
        var filePath = path.join('./content', f),
            copyPath = path.join('./dist', f);
        fs.createReadStream(filePath).pipe(fs.createWriteStream(copyPath));
    });
});