chrome.runtime.sendMessage("Test");

chrome.runtime.onMessage.addListener(function(message, sender, sendResponse) {
    var yes = document.getElementsByClassName("gb_Oa gb_dd gb_xg gb_i gb_Mf gb_ma");
    console.log(yes);
});