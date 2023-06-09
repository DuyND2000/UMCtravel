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
                    alert("Danh sách khách hàng của chúng tôi đã có bạn, chúng tôi sẽ cập nhật thông tin thay đổi từ bạn");
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
        title: "Bạn có chắc chắn chưa?",
        text: "Tôi muốn đặt chuyến bây giờ",
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
                            swal({
                                title: "Thành công!",
                                text: "Chuyến đi đã được đặt",
                                type: "success",
                                timer: 3000
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

