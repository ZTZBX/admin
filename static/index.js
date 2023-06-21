window.players = [];
window.items = []



function addItemToInvt(item)
{
    fetch(`https://admin/give_item_to_me`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        },
        body: JSON.stringify({
            item: item,
            quantity: Number($("#item_value_"+item+"").val())
        })
    })
}

function showPlayerOption(user){
    
    var box = document.getElementById("player_"+user);

    if (box.clientHeight == 40){
        box.style.height = "140px";
        var up_row = document.getElementById("user_option_image_up_"+user);
        up_row.style.display = "inline";

        var up_down = document.getElementById("user_option_image_down_"+user);
        up_down.style.display = "none";

        document.getElementById("option_"+user).style.display = "inline-block";
        
    }
    else {

        box.style.height = "40px";
        var up_row = document.getElementById("user_option_image_up_"+user);
        up_row.style.display = "none";

        var up_down = document.getElementById("user_option_image_down_"+user);
        up_down.style.display = "inline";

        document.getElementById("option_"+user).style.display = "none";

    }
    

}

function showUtl() {
    var target = document.getElementById("utilities_menu");
    var other_pl = document.getElementById("players_menu");
    var other_pl_2 = document.getElementById("items_menu");

    if (other_pl.style.display !== "none") {
        other_pl.style.display = "none";
    }

    if (other_pl_2.style.display !== "none") {
        other_pl_2.style.display = "none";
    }

    if (target.style.display === "none") {
        target.style.display = "block";
    }
}

function showPlayers() {
    var target = document.getElementById("players_menu");
    var other_pl = document.getElementById("utilities_menu");
    var other_pl_2 = document.getElementById("items_menu");

    if (other_pl.style.display !== "none") {
        other_pl.style.display = "none";
    }

    if (other_pl_2.style.display !== "none") {
        other_pl_2.style.display = "none";
    }

    if (target.style.display === "none") {
        target.style.display = "block";
    }
}

function showItemsMenu() {
    var target = document.getElementById("items_menu");
    var other_pl = document.getElementById("utilities_menu");
    var other_pl_2 = document.getElementById("players_menu");

    if (other_pl.style.display !== "none") {
        other_pl.style.display = "none";
    }

    if (other_pl_2.style.display !== "none") {
        other_pl_2.style.display = "none";
    }

    if (target.style.display === "none") {
        target.style.display = "block";
    }
}

function changeCoords(new_coords) {
    coords = JSON.parse(new_coords["coords"])
    document.getElementById("z_coord").innerText = coords.z
    document.getElementById("x_coord").innerText = coords.x
    document.getElementById("y_coord").innerText = coords.y
}

function banPlayer(user) {
    fetch(`https://admin/banplayer`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        },
        body: JSON.stringify({
            username: user
        })
    });
}

function chickPlayer(user) {
    fetch(`https://admin/serverKick`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        },
        body: JSON.stringify({
            username: user,
            reason: "Administrator kicked you!"
        })
    })
}

function tpa(user) {
    fetch(`https://admin/tpa`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        },
        body: JSON.stringify({
            username: user,
        })
    })
}

function tpme(user) {
    fetch(`https://admin/tpme`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        },
        body: JSON.stringify({
            username: user,
        })
    })
}

function freeze(user) {
    fetch(`https://admin/freeze`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        },
        body: JSON.stringify({
            username: user,
        })
    })
}

function generateItemHtml(itemName) {
    var players_base ='\
    <div class="player" id="item_'+itemName+'">\
    <p style="float: left;">'+itemName+'</p>\
    <input type="number"  onkeypress="return event.charCode >= 48" min="1" id="item_value_'+itemName+'" class="form-control" style="float: left;margin-left:20px;width:90px;height:30px" />\
    <a href="#" class="btn" style="padding: 0 5px;" onClick="addItemToInvt(\''+itemName+'\')" name="item_'+itemName+'" style="margin-top:0!important;" >Get</a>\
    </div>';

    return players_base;
}

function generatePlayerHtml(username) {
    var players_base ='\
    <div class="player" id="player_'+username+'">\
    <p style="float: left;">'+username+'</p>\
    <div class="user_option" onclick="showPlayerOption(\''+username+'\')">\
    <svg class="user_option_image" id="user_option_image_down_'+username+'"\
    xmlns="http://www.w3.org/2000/svg" width="20" height="20"\
    fill="#1f2029" class="bi bi-arrow-down" viewBox="0 0 16 16">\
    <path fill-rule="evenodd"\
    d="M8 1a.5.5 0 0 1 .5.5v11.793l3.146-3.147a.5.5 0 0 1 .708.708l-4 4a.5.5 0 0 1-.708 0l-4-4a.5.5 0 0 1 .708-.708L7.5 13.293V1.5A.5.5 0 0 1 8 1z" />\
    </svg>\
    <svg class="user_option_image" id="user_option_image_up_'+username+'"\
    style="display: none;" xmlns="http://www.w3.org/2000/svg" width="20"\
    height="20" fill="#1f2029" class="bi bi-arrow-down"\
    viewBox="0 0 16 16">\
    <path fill-rule="evenodd"\
    d="M8 15a.5.5 0 0 0 .5-.5V2.707l3.146 3.147a.5.5 0 0 0 .708-.708l-4-4a.5.5 0 0 0-.708 0l-4 4a.5.5 0 1 0 .708.708L7.5 2.707V14.5a.5.5 0 0 0 .5.5z" />\
    </svg>\
    </div>\
    <div class="player_option" id="option_'+username+'" style="display: none;">\
    <a href="#" onClick="banPlayer(\''+ username + '\')" class="btn mt-4">ban</a> \
    <a href="#" onClick="chickPlayer(\''+ username + '\')" class="btn mt-4">kick</a> \
    <a href="#" onClick="tpme(\''+ username + '\')" class="btn mt-4">tpme</a> \
    <a href="#" onClick="tpa(\''+ username + '\')" class="btn mt-4">tpa</a> \
    <a href="#" onClick="freeze(\''+ username + '\')" class="btn mt-4">Freeze</a> \
    </div>\
    </div>';

    return players_base;
}

function filterPlayers() {
    var input = document.getElementById('playersFilter');
    filter = input.value.toUpperCase();

    for (var i in window.players) {
        if (!window.players[i].toUpperCase().includes(filter)) {
            document.getElementById("player_" + window.players[i]).style.display = "none";
        }
        else {
            document.getElementById("player_" + window.players[i]).style.display = "block";
        }
    }

}

function filterItems() {
    var input = document.getElementById('itemsFilter');
    filter = input.value.toUpperCase();

    for (var i in window.items) {
        if (!window.items[i][0].toUpperCase().includes(filter)) {
            document.getElementById("item_" + window.items[i][0]).style.display = "none";
        }
        else {
            document.getElementById("item_" + window.items[i][0]).style.display = "block";
        }
    }

}

function addPlayers(players) {

    document.getElementById("players_menu").innerHTML = '<input type="text" id="playersFilter" onkeyup="filterPlayers()" placeholder="Username Filter" style="width: 90%; margin-bottom: 1rem; position: sticky;top: 0;" class="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm">';

    window.players = JSON.parse(players["data"]).players;

    for (var i in window.players) {
        document.getElementById("players_menu").innerHTML += generatePlayerHtml(window.players[i]);
    }

}


function addItem(item) {
    document.getElementById("items_menu").innerHTML = '<input type="text" id="itemsFilter" onkeyup="filterItems()" placeholder="Item Filter" style="width: 90%; margin-bottom: 1rem; position: sticky;top: 0;" class="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm">';

    window.items = JSON.parse(item["data"]);
    for (var i in window.items) {
        document.getElementById("items_menu").innerHTML += generateItemHtml(window.items[i][0]);
    }

}

$(function () {

    $("#getplayers").click(function () {
        fetch(`https://admin/getplayers`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
            })
        }).then(resp => resp.json()).then(success => addPlayers(success));
    });

    $("#getItems").click(function () {
        fetch(`https://admin/get_items_meta_data`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
            })
        }).then(resp => resp.json()).then(success => addItem(success));
    });
    

    window.addEventListener('message', function (event) {
        var item = event.data;

        if (item.showAdmin == true) {

            fetch(`https://admin/coords`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify({
                })
            }).then(resp => resp.json()).then(success => changeCoords(success));

            document.getElementsByClassName("main")[0].style.display = "block";

        }
        else {
            document.getElementsByClassName("main")[0].style.display = "none";
        }
    });

    $("#exit").click(function () {

        fetch(`https://admin/exit`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
            })
        }).then()
        .catch(err => {   
        });
    });


    $("#kick_me").click(function () {

        fetch(`https://admin/serverKick`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                username: "me",
                reason: "Admin kick test"
            })
        })
    });


    $("#die").click(function () {

        fetch(`https://admin/kill`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
            })
        }).then(resp => resp.json()).then(
            resp => document.getElementById("error_message").innerHTML = resp["error"]
        ).then(
            resp => document.getElementById("error_message").style.display = "block"
        );
    });

    $("#noclip").click(function () {

        fetch(`https://admin/noclip`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
            })
        }).then(resp => resp.json()).then(
            resp => document.getElementById("error_message").innerHTML = resp["error"]
        ).then(
            resp => document.getElementById("error_message").style.display = "block"
        );
    });


    $("#invincible").click(function () {

        fetch(`https://admin/invincible`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
            })
        }).then(resp => resp.json()).then(
            resp => document.getElementById("error_message").innerHTML = resp["error"]
        ).then(
            resp => document.getElementById("error_message").style.display = "block"
        );
    });
});