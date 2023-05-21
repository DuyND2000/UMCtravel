function BookingTour() {
    var participantCount = document.getElementById('participantCount');
    var appendParticipantCount = document.getElementById('appendParticipantCount');
    if (participantCount.value != null) {
        appendParticipantCount.value = participantCount.value;
    }
    var startDate = document.getElementById('startDate');
    var appendStartDate = document.getElementById('appendStartDate');
    appendStartDate.value = startDate.value;
    $('#ExpectedPrice').val(parseInt($('#appendParticipantCount').val()) * parseFloat($('#Price').val()));
}
function BookTour(item) {
    var unindexed_array = $('#' + item).serializeArray();
    var indexed_array = {};
    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });
    var phone = indexed_array["Customer.Phone"];
    var email = indexed_array["Customer.Email"];
    if (phone != "") {
        $.ajax({
            type: "Get",
            url: "/Tour/GetCustomerByPhoneAndEmail",
            data: { phone: phone,email:email },
            success: function (res) {
                if (res != null) {
                    alert("Our customer list already has you, we will update the information changes from you");
                    indexed_array["Customer.CustomerId"] = res.customerId;
                } else {
                    indexed_array["Customer.CustomerId"] = "0";
                }
                CreateBooking(indexed_array);
            }
        })
    } else {
        indexed_array["Customer.CustomerId"] = "0";
        CreateBooking(indexed_array);
    }

}
function CreateBooking(indexed_array) {
    swal({
        title: "Are you sure?",
        text: "You want booking nows",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    type: "Post",
                    url: "/Tour/BookTour",
                    data: indexed_array,
                    success: function (response) {
                        var parsed = $.parseHTML(response);
                        var hasError = $(parsed).find("input[name='IsValidBooking']").val() == "false";
                        if (hasError) {
                            $('#formbooking').html(response);
                            $('#booking').click();
                        } else {
                            swal("Tour Bookings!", {
                                icon: "success",
                                timer: 50000
                            });
                            location.href = "/Tour/index";
                        }
                    },
                    error: function (e) {
                        console.log(e);
                    }

                })
               
            } else {

            }
        });
}

