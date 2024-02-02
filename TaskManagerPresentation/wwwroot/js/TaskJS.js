$(document).ready(function () {
    GetTasks();
});

$('#btnCreate').click(function () {
    $('#TaskModal').modal('show');
    setModal("Create");
    GetStatutses();
});

$('#btnUpdate').click(function () {
    var selectedRow = $('tbody tr.selectedRow');

    if (selectedRow.length > 0) {
        var taskId = selectedRow.attr('data-id');

        setModal("Update");
        $('#TaskModal').modal('show');
        GetStatutses();
        Edit(taskId);
    }
    else {
        alert("Выберите задачу для редактирования");
    }
});

$('#btnDelete').click(function () {
    var selectedRow = $('tbody tr.selectedRow');

    if (selectedRow.length > 0) {
        var taskId = selectedRow.attr('data-id');
        Delete(taskId);
    }
    else {
        alert("Выберите задачу для редактирования");
    }
});

$('#Name').change(function () {
    Validate();
})

$('#Description').change(function () {
    Validate();
})

$('#statusDropdown').change(function () {
    Validate();
})

function HideModal() {
    ClearData();
    $('#TaskModal').modal('hide');
}
function ClearData() {
    $('#Name').val('');
    $('#Description').val('');
    $('#statusDropdown').val('');
}
function Validate() {
    var isValid = true;

    if ($('#Name').val().trim() == '') {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }

    if ($('#Description').val().trim() == '') {
        $('#Description').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Description').css('border-color', 'lightgrey');
    }

    if ($('#statusDropdown').val() == null) {
        $('#statusDropdown').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#statusDropdown').css('border-color', 'lightgrey');
    }
    console.log(isValid);
    return isValid;
}
function GetStatutses() {
    $.ajax({
        url: '/Tasks/GetStatuses',
        type: 'get',
        datatype: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            console.log(response);

            if (response == null || response == undefined || response == 0) {
                return;
            }
            else {
                var statusDropdown = $('#statusDropdown');
                statusDropdown.empty();
                $.each(response, function (index, status) {
                    statusDropdown.append('<option value="' + status.id + '">' + status.name + '</option>');
                });
            }
        }
    });
}
function GetTasks() {
    $.ajax({
        url: '/Tasks/GetTasks',
        type: 'get',
        datatype: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (response) {

            if (response == null || response == undefined || response == 0) {
                return;
            }
            else {
                $('tbody').empty();

                $.each(response, function (index, task) {
                    var row = $('<tr>');

                    row.attr('data-id', task.id);

                    row.append($('<td>').text(task.name));
                    row.append($('<td>').text(task.description));
                    row.append($('<td>').text(task.status.name));

                    row.click(function () {
                        selectRow(row);
                    });

                    $('tbody').append(row);
                });

                $('tbody').click(function (event) {
                    event.stopPropagation();
                });

                $(document).click(function () {
                    selectRow(null);
                });
            }
        }
    });
}
function selectRow(selectedRow) {
    $('tbody tr').removeClass('selectedRow');

    if (selectedRow) {
        selectedRow.addClass('selectedRow');
    }
}
function Edit(id) {
    $.ajax({
        url: '/Tasks/Edit',
        type: 'post',
        datatype: 'json',
        contentType: 'application/json;charset=utf-8',
        data: JSON.stringify(parseInt(id)),
        success: function (response) {
            console.log(response);
            if (response == null || response == undefined || response == 0) {
                return;
            }
            else {
                $('#Id').val(response.id);
                $('#Name').val(response.name);
                $('#Description').val(response.description);
                $('#statusDropdown').val(response.statusId);
            }
        }
    });
}
function Create() {

    if (!Validate()) {
        return;
    }

    var data = {
        name: $('#Name').val(),
        description: $('#Description').val(),
        statusId: parseInt($('#statusDropdown').val())
    };

    $.ajax({
        url: '/Tasks/Create',
        type: 'post',
        contentType: 'application/json;charset=utf-8',
        data: JSON.stringify(data),
        success: function (response) {
            if (response == null || response == undefined || response == 0) {
                alert('Не удалось добавить задачу');
            }
            else {
                HideModal();
                GetTasks();
                alert(response);
            }
        },
        error: function () {
            alert('Не удалось добавить задачу');
        }
    });
}
function Update() {

    if (!Validate()) {
        return;
    }

    var data = {
        id: parseInt($('#Id').val()),
        name: $('#Name').val(),
        description: $('#Description').val(),
        statusId: parseInt($('#statusDropdown').val())
    };

    $.ajax({
        url: '/Tasks/Update',
        type: 'post',
        contentType: 'application/json;charset=utf-8',
        data: JSON.stringify(data),
        success: function (response) {
            if (response == null || response == undefined || response == 0) {
                alert('Не удалось изменить задачу');
            } else {
                HideModal();
                GetTasks();
                alert(response);
            }
        },
        error: function () {
            alert('Не удалось изменить задачу');
        }
    });
}
function setModal(action) {
    var modalTitle = $('#modalTitle');
    var btnDone = $('#btnDone');

    if (action === "Create") {
        modalTitle.text("Добавить задачу");
        btnDone.text("Добавить");
        btnDone.off("click").on("click", function () {
            Create();
        });
    } else if (action === "Update") {
        modalTitle.text("Редактировать задачу");
        btnDone.text("Сохранить");
        btnDone.off("click").on("click", function () {
            Update();
        });
    }
}

function Delete(id) {
    $.ajax({
        url: '/Tasks/Delete',
        type: 'post',
        contentType: 'application/json;charset=utf-8',
        data: JSON.stringify(parseInt(id)),
        success: function (response) {
            if (response == null || response == undefined || response == 0) {
                alert('Не удалось удалить задачу');
            } else {
                GetTasks();
                alert(response);
            }
        },
        error: function () {
            alert('Не удалось изменить задачу');
        }
    });
}
