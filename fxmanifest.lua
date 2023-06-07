fx_version 'bodacious'
game 'gta5'

files {
    'Client/*.dll',
    'static/index.css',
    'static/index.js',
    'static/index.html'
}

client_script 'Client/*.net.dll'
server_script 'Server/*.net.dll'

author 'zabbix-byte'
version '1.0.0'
description 'ztzbx admin'

dependencies {
    "core-ztzbx",
    "inventory",
    "notification"
}

ui_pages {
    'static/index.html'
}