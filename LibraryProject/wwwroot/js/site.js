let spinnerVisible = false;

function showProgress() {
    if (!spinnerVisible) {
        $("span#spinner").addClass("is-active");
        spinnerVisible = true;
    }
}

function hideProgress() {
    if (spinnerVisible) {
        let spinner = $("span#spinner");
        spinner.stop();
        spinner.removeClass("is-active");
        spinnerVisible = false;
    }
}

function onBegin() {
    showProgress();
}

function onFailure(response) {
    hideProgress();
    messageAlertWithError();
}

function onSuccess(response) {
    let errorMessages = "";

    $(".error-definition").html("");
    $(".modal-error-messages").html("");

    hideProgress();

    if (!response.isSuccess) {
        $.each(response.errors, function (index, value) {
            errorMessages += `<li>${value}</li>`;
        });

        messageAlert(response.icon, response.title, errorMessages.split("\n").join("<br />"));
    }

    if (response.isSuccess && !isNil(response.successMessage)) {
        messageAlert(response.icon, response.title, response.successMessage);
    }


    if (!isNil(response.function)) {
        window[response.function](response.data);
    }

    if (!isNil(response.url)) {
        setTimeout(function () {
            window.location.assign(response.url);
        }, 1000)
    }
}

function messageAlert(icon, title, text) {
    Swal.fire({
        icon: icon,
        title: title,
        html: text,
        confirmButtonText: "Tamam",
    });
}

function messageAlertWithError() {
    messageAlert("error", "Uygulama Hatası", "Bir hata meydana geldi.Lütfen ilgili kişilerle iletişime geçiniz !")
}


function isNil(val) {
    return val === undefined || val === null || val === "";
}

function pageReflesh() {
    setTimeout(function () {
        location.reload();
    }, 1000);
}

$(document).ready(function () {
    $(".editBook").click(function () {
        const bookId = $(this).data("id");
        $("#bookId").val(bookId);
        $("#exampleModal").modal("show");
    });

    $("#saveBook").click(function () {
        const bookId = $("#bookId").val();
        let returnDate = $("#returnDate").val();
        let borrower = $("#borrower").val();

        $.ajax({
            url: "/Home/LendBook",
            type: "POST",
            data: {
                id: bookId,
                returnDate: returnDate,
                borrower: borrower,
                '__RequestVerificationToken': $('[name="__RequestVerificationToken"]').val()
            },
            success: function (response) {
                if (response.isSuccess) {
                    $("#exampleModal").modal("hide");
                    messageAlert(response.icon, response.title, response.successMessage)
                    pageReflesh();
                }
                else {
                    onSuccess(response);
                }

            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    });

    $('.deliver').click(function () {
        var bookId = $(this).data('id');

        Swal.fire({
            title: 'Teslim etmek istediğinize emin misiniz?',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet',
            cancelButtonText: 'İptal'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Home/DeliverBook',
                    method: 'POST',
                    data: {
                        bookId: bookId,
                        '__RequestVerificationToken': $('[name="__RequestVerificationToken"]').val()
                    },
                    success: function (response) {
                        if (response.isSuccess) {
                            $("#exampleModal").modal("hide");
                            messageAlert(response.icon, response.title, response.successMessage)
                            pageReflesh();
                        }
                        else {
                            onSuccess(response);
                        }
                    },
                    error: function (xhr, status, error) {
                        console.error(xhr.responseText);
                    }
                });
            }
        });
    });
});