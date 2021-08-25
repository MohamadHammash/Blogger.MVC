
let qaContainerBtn = document.querySelector('#qa-accordion-container');

let buttons = qaContainerBtn.getElementsByTagName('button');

function scrollUp(elementId) {
    window.scrollTo(0, 500);
}

function init() {
    for (let i = 0; i < buttons.length; i++) {
        const element = buttons[i];

        let attr = element.getAttribute('aria-controls');

        if (window.addEventListener) {
            buttons[i].addEventListener('click', function () {
                scrollUp(attr)
            });
        } else if (window.attachEvent) {
            buttons[i].attachEvent('click', function () {

                scrollUp(attr)
            });
        }
    }
}

if (window.addEventListener) {
    document.addEventListener("DOMContentLoaded", init, false);
} else if (window.attachEvent) {
    document.attachEvent("onDOMContentLoaded", init);
}


