(function () {
    "use strict";
    
    // Function to safely add an event listener if the element exists
    function addEventListenerIfElementExists(selector, event, handler) {
        const element = document.querySelector(selector);
        if (element) {
            element.addEventListener(event, handler);
        }
    }

    var myElement1 = document.getElementById('chat-msg-scroll');
    new SimpleBar(myElement1, { autoHide: true });

    var myElement2 = document.getElementById('groups-tab-pane');
    new SimpleBar(myElement2, { autoHide: true });

    var myElement3 = document.getElementById('calls-tab-pane');
    new SimpleBar(myElement3, { autoHide: true });

    var myElement4 = document.getElementById('main-chat-content');
    new SimpleBar(myElement4, { autoHide: true });

    var myElement5 = document.getElementById('chat-user-details');
    new SimpleBar(myElement5, { autoHide: true });

    addEventListenerIfElementExists(".responsive-chat-close", "click", () => {
        document.querySelector(".main-chart-wrapper").classList.remove("responsive-chat-open");
    });

    document.querySelectorAll(".responsive-userinfo-open").forEach((ele) => {
        ele.addEventListener("click", () => {
            document.querySelector("#chat-user-details").classList.add("open");
        });
    });

    addEventListenerIfElementExists(".responsive-chat-close2", "click", () => {
        document.querySelector("#chat-user-details").classList.remove("open");
    });

    addEventListenerIfElementExists(".chat-info", "click", () => {
        document.querySelector("#chat-user-details").classList.remove("open");
    });

    addEventListenerIfElementExists(".chat-content", "click", () => {
        document.querySelector("#chat-user-details").classList.remove("open");
    });
})();

let changeTheInfo = (element, name, img, status) => {
    document.querySelectorAll(".checkforactive").forEach((ele) => {
        ele.classList.remove("active");
    });
    element.closest("li").classList.add("active");
    document.querySelectorAll(".chatnameperson").forEach((ele) => {
        ele.innerText = name;
    });
    let image = `../assets/images/faces/${img}.jpg`;
    document.querySelectorAll(".chatimageperson").forEach((ele) => {
        ele.src = image;
    });

    document.querySelectorAll(".chatstatusperson").forEach((ele) => {
        ele.classList.remove("online");
        ele.classList.remove("offline");
        ele.classList.add(status);
    });

    document.querySelector(".chatpersonstatus").innerText = status;

    document.querySelector(".main-chart-wrapper").classList.add("responsive-chat-open");
};