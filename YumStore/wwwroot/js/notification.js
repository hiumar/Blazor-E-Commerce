debugger
window.ShowToaster = function (type, message) {
    debugger
    if (type == "success") {
        toastr.success(message)
    }
    if (type == "error") {
        toastr.error(message);
    }
}