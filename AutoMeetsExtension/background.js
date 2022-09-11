chrome.runtime.onMessage.addListener(function(request, sender) {
  chrome.tabs.query({active: true}, function(tabs){
    if(tabs[0].url === "https://sites.google.com/view/automeets-launch-site/home") {
      chrome.tabs.remove(tabs[0].id);
    }
  });
  chrome.tabs.create({url: "https://www.google.com"});
  chrome.tabs.sendMessage(0, "Test1");
});