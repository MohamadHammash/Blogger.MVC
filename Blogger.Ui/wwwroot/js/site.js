/*upload buttons*/

document.querySelector(".upload").onchange = function () {
    let uploadValue = this.value;
    let last = uploadValue.lastIndexOf('\\');
    let subValue = uploadValue.substring(last + 1);

    document.querySelector(".uploadFile-disabled").value = subValue;
};

/*upload buttons end*/