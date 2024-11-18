var token = localStorage.getItem('jwtToken');

$(document).ready(function () {

    const userId = getUserIdFromToken(token);
    console.log('User ID:', userId[1]);


    $('#supportForm').on('submit', function (event) {
        event.preventDefault();
        var message = $('#message').val();
        var subject = $('#subject').val();
        var supportForm = {
            UserId: userId[1],
            Subject: subject,
            Message: message,
            Status: 0
        }
        $.ajax({
            type: 'POST',
            url: 'https://localhost:44375/api/Form/AddForm', 
            contentType: 'application/json',
            data: JSON.stringify(supportForm),
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + token);
            },
            success: function (response) {
                console.log('Form başarıyla gönderildi:', response);
                Swal.fire({
                    title: "Başarılı bir şekilde gönderildi!",
                    text: "Mesajınız başarılı gönderildi!",
                    icon: "success"
                });
                $('#supportForm')[0].reset(); 
            },
            error: function (xhr, status, error) {
                UnAuthorize(xhr.status)
                console.error('Form gönderiminde hata:', xhr);
                alert('Form gönderiminde bir hata oluştu. Lütfen tekrar deneyin.');
            }
        });
    });
  
});
