$(function () {
    var userLoginButton = $("#Login button[name='login']").click(onUserLoginClick);

    function onUserLoginClick() {
        var url = "/UserAuth/Login";

        var antiForgeryToken = $("#Login input[name='__RequestVerificationToken']").val();

        var email = $("#Login input[name='Email']").val();
        var password = $("#Login input[name='Password']").val();
        var rememberMe = $("#Login input[name='RememberMe']").val();

        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            RememberMe: rememberMe
        };

        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) {
                var parsed = $.parseHTML(data);
                var hasErrors = $(parsed).find("input[name='LoginValid']").val() == "false";

                if (hasErrors == true) {
                    $("#loginModal #Login").html(data);

                    userLoginButton = $("#Login button[name='login']").click(onUserLoginClick);

                    /*document.getElementById("defaultOpen").click();*/
                }
                else {
                    var returnUrl = $(parsed).find("input[name='LoginValid']").val();
                    if (returnUrl != "") {
                        location.href = returnUrl;
                    }
                    else {
                        location.href = "/Home/Index";
                    }
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    }
});

$(function () {
    var userRegisterButton = $("#Register button[name='register']").click(onUserRegisterClick);

    function onUserRegisterClick() {
        var url = "/UserAuth/Register";

        var antiForgeryToken = $("#Register input[name='__RequestVerificationToken']").val();

        var firstName = $("#Register input[name='FirstName']").val();
        var lastName = $("#Register input[name='LastName']").val();
        var phoneNumber = $("#Register input[name='PhoneNumber']").val();
        var email = $("#Register input[name='SignUpEmail']").val();
        var password = $("#Register input[name='SignUpPassword']").val();
        var confirmPassword = $("#Register input[name='ConfirmPassword']").val();

        var user = {
            __RequestVerificationToken: antiForgeryToken,
            FirstName: firstName,
            LastName: lastName,
            PhoneNumber: phoneNumber,
            SignUpEmail: email,
            SignUpPassword: password,
            ConfirmPassword: confirmPassword,
            AcceptAgreement: true,
        };

        $.ajax({
            type: "POST",
            url: url,
            data: user,
            success: function (data) {
                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='RegistrationValid']").val() == "false";

                if (hasErrors == true) {
                    $("#loginModal #Register").html(data);
                    userRegisterButton = $("#Register button[name='register']").click(onUserRegisterClick);
                    Agree();
                    $("#UserRegistrationForm").removeData("validator");
                    $("#UserRegistrationForm").removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse("#UserRegistrationForm");
                }
                else {
                    location.href = "/Home/Index?waitingVerify=wait";
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    }
});

function openCity(evt, cityName) {
    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";
}

function Agree() {
    if (!$("#AcceptAgreement").prop('checked')) {
        $("#register").attr('disabled', 'disabled');
    }
    else {
        $("#register").removeAttr('disabled');
    }
};

function loginReturnUrl() {
    var path = window.location.pathname;
    window.location.href = "/Home/Index?returnUrl=" + path;
};

$(document).ready(function () {

    function setRating(rating) {
        $('#RatePoint').val(rating);
        // fill all the stars assigning the '.selected' class
        $('.rating-star').addClass('text-warning').addClass('selected');
        // empty all the stars to the right of the mouse
        $('.rating-star#rating-' + rating + ' ~ .rating-star').removeClass('selected').removeClass('text-warning');
    }
    var x = 0;
    $('.rating-star')
        .on('mouseover', function (e) {
            var rating = $(e.target).data('rating');
            // fill all the stars
            $('.rating-star').addClass('text-warning');
            // empty all the stars to the right of the mouse
            $('.rating-star#rating-' + rating + ' ~ .rating-star').removeClass('text-warning');
        })
        .on('mouseleave', function (e) {
            var rating = $('#RatePoint').val();
            // empty all the stars except those with class .selected
            $('.rating-star#rating-' + rating + ' ~ .rating-star').removeClass('text-warning');
            while (rating > 0) {
                $('.rating-star#rating-' + rating).addClass('text-warning');
                rating--;
            }
        })
        .on('click', function (e) {
            var rating = $(e.target).data('rating');
            setRating(rating);
            x = 1;
        })
});