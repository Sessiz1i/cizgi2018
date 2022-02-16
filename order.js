//jquery code
$ = jQuery.noConflict()
$('.carousel').carousel({
    interval: 2000
})

// Kapak Modal
const openKModal = () => {
    $(document).ready(function () {
        $('#kapakModal').modal("show");
        setTimeout(function (){$('.carousel-control-prev').focus()},600)
    })
};

// Cancel Enter PosBack
document.addEventListener("keydown", function () {
    if (event.key === 'Enter') {
        event.preventDefault()
    }
})

// Extra Tab
const extraTab = (tabId) => {
    if (tabId && tabId > 0) {
        const tabButtons = document.getElementsByClassName('tab-button')
        const tabContents = document.getElementsByClassName('tab-content')
        for (const tabButton of tabButtons) {
            tabButton.id === `tab-btn-${tabId}` ? tabButton.classList.add("ui-state-active") : tabButton.classList.remove("ui-state-active")
        }
        for (const tabContent of tabContents) {
            tabContent.id === `tab-content-${tabId}` ? tabContent.style.display = "block" : tabContent.style.display = "none"
        }
    }
}

// Slider Active
const isActive = document.getElementsByClassName("carousel-item")
if (isActive.length > 0) {
    document.getElementsByClassName("carousel-item")[0].classList.add("active");
    document.getElementsByClassName("list-inline-item")[0].classList.add("active");
    document.getElementsByClassName("list-inline-item")[0].children[0].classList.add("selected")
}

// Handel Search
const handelSearch = (s) => {
    let searchInput = document.getElementById("search")
    const schText = s ? s : event.target.value
    const panels = document.getElementsByClassName("order-kapak")
    for (const panel of panels) {
        if (panel.children[1].textContent && !RegExp(schText, 'i').test(panel.children[1].textContent)) {
            panel.parentElement.style.display = "none"
        } else {
            panel.parentElement.removeAttribute("style")
        }
    }
}

var parameter = Sys.WebForms.PageRequestManager.getInstance();
parameter.add_endRequest(async function () {
    
    $('.carousel').carousel({
        interval: 2000
    })

    // Cancel Enter PosBack
    document.addEventListener("keydown", function () {
        if (event.key === 'Enter') {
            event.preventDefault()
        }
    })

  /*  // Extra Tab
    const extraTab = (tabId) => {
        if (tabId && tabId > 0) {
            const tabButtons = document.getElementsByClassName('tab-button')
            const tabContents = document.getElementsByClassName('tab-content')
            for (const tabButton of tabButtons) {
                tabButton.id === `tab-btn-${tabId}` ? tabButton.classList.add("ui-state-active") : tabButton.classList.remove("ui-state-active")
            }
            for (const tabContent of tabContents) {
                tabContent.id === `tab-content-${tabId}` ? tabContent.style.display = "block" : tabContent.style.display = "none"
            }
        }
    }*/

    // Slider Active
    const isActive = document.getElementsByClassName("carousel-item")
    if (isActive.length > 0) {
        document.getElementsByClassName("carousel-item")[0].classList.add("active");
        document.getElementsByClassName("list-inline-item")[0].classList.add("active");
        document.getElementsByClassName("list-inline-item")[0].children[0].classList.add("selected")
    }

    // Handel Search
    const handelSearch = (s) => {
        let searchInput = document.getElementById("search")
        const schText = s ? s : event.target.value
        const panels = document.getElementsByClassName("order-kapak")
        for (const panel of panels) {
            if (panel.children[1].textContent && !RegExp(schText, 'i').test(panel.children[1].textContent)) {
                panel.parentElement.style.display = "none"
            } else {
                panel.parentElement.removeAttribute("style")
            }
        }
    }
});