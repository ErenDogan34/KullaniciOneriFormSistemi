$(document).ready(function () {
    $('#registerForm').on('submit', function (event) {
        event.preventDefault(); 
        console.log("sdfghjk")
        var username = $('#username').val();
        var name = $('#name').val();
        var lastName = $('#lastName').val();
        var email = $('#email').val();
        var password = $('#password').val();

        var hasUpperCase = /[A-Z]/.test(password); 
        var hasLowerCase = /[a-z]/.test(password); 
        var isLengthValid = password.length >= 6 && password.length <= 20; 

        if (!isLengthValid || !hasUpperCase || !hasLowerCase) {
            $('#registerError').text("Şifre en az 6-20 karakter olmalı, en az bir büyük ve bir küçük harf içermelidir.").show(); 
            return;
        } else {
            $('#registerError').hide(); 
        }
        var user = {
            username: username,
            name: name,
            lastName: lastName,
            email: email,
            password: password
        };

        $.ajax({
            url: 'https://localhost:44375/api/User/Register', 
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(user),
            success: function (response) {
                console.log("Kullanıcı başarıyla kaydedildi:", response);
                $('#registerError').hide(); 
                alert("Kayıt başarılı! Giriş yapabilirsiniz.");
                window.location.href = '/Auth/Login';
            },
            error: function (xhr, status, error) {
                Swal.fire({
                    icon: "error",
                    title: "Oops...",
                    text: "Email ekli!",
                });
                console.error("Kayıt sırasında hata oluştu:", error);
                $('#registerError').text("Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.").show(); 
            }
        });
    });
});
