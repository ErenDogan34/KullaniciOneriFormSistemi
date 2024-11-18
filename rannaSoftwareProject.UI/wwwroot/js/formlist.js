var token = localStorage.getItem('jwtToken');

$(document).ready(function () {
    loadSupportForms();

    function loadSupportForms() {
        $.ajax({
            type: 'GET',
            url: 'https://localhost:44375/api/Form/GetAllForm',
            contentType: 'application/json',
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + token);
            },
            success: function (response) {
                populateTable(response);
                console.log(response)
            },
            error: function (xhr, status, error) {
                console.log(token)
                UnAuthorize(xhr.status)
                console.error('Veri yüklenirken hata:', error);
            }
        });
    }

    function populateTable(forms) {
        var tbody = $('#dataTable tbody');
        tbody.empty();
        var status = 0;
        forms.forEach(function (form) {
            loadFormById(form.userId, function (userName) {

                if (form.status == 0) {
                    status = 'İşlemde'
                }
                if (form.status == 1) {
                    status = 'Okundu'
                }
                var row = `<tr>
              <td>${userName}</td>
              <td>${form.subject}</td>
              <td>${form.message}</td>
              <td>${status}</td>
              <td><button class="btn btn-danger" onclick="markAsRead(${form.id})">Okundu</button></td>
              <td><button class="btn btn-info" onclick="deleteForm(${form.id})">Sil</button></td>
          </tr>`;
                tbody.append(row);
            });
        });
    }

    function loadFormById(id, callback) {
        $.ajax({
            type: 'GET',
            url: `https://localhost:44375/api/User/GetById/?id=${id}`,
            contentType: 'application/json',
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + token);
            },
            success: function (response) {
                callback(response);
            },
            error: function (xhr, status, error) {
                console.error('Form detayları yüklenirken hata:', error);
                alert('Form detaylarını yüklerken bir hata oluştu.');
                callback('N/A');
            }
        });
    }
    window.markAsRead = function (formId) {
        $.ajax({
            type: 'POST',
            url: 'https://localhost:44375/api/Form/FormProcessed/?id=' + formId,
            contentType: 'application/json',
            success: function (response) {
                console.log('Form başarıyla okundu olarak işaretlendi:', response);
                alert('Form başarıyla okundu olarak işaretlendi.');
                loadSupportForms();
            },
            error: function (xhr, status, error) {
                console.error('Form okundu olarak işaretlenirken hata:', xhr.responseText);
                alert('Form okundu olarak işaretlenirken bir hata oluştu: ' + xhr.responseText);
            }
        });
    }

    window.deleteForm = function (id) {
        if (confirm('Bu formu silmek istediğinize emin misiniz?')) {
            $.ajax({
                type: 'DELETE',
                url: `https://localhost:44375/api/Form/DeleteForm/?id=` + id,
                success: function (response) {
                    alert('Form başarıyla silindi.');
                    loadSupportForms();
                },
                error: function (xhr, status, error) {
                    console.error('Form silinirken hata:', xhr);
                    alert('Silme işlemi sırasında hata oluştu.');
                }
            });
        }
    }
})