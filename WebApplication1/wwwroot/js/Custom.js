$(document).ready(function(){
    DataInTable();
});
function DataInTable() { 
    $.ajax({
        url: "/Ajax/GetAll",
        type: "Get",
        dataType: "json",
        contentType: 'application/json;charset=utf-8;',
        success: function (data) {
            if (data == null || data.length == 0 || data == undefined) {
                var row = "";
                row += '<tr>';
                row += `<td "colspan = 5">DATA not fatched :</td>`;
                row += '</tr>';
                $('#tabledata').html(row);
            }
            else {
                var row = "";
                $.each(data, function (index, item) {
                    row += '<tr>';
                    row += '<td>' + item.id + '</td>';
                    row += '<td>' + item.name + '</td>';
                    row += '<td>' + item.course + '</td>';
                    row += '<td>' + item.gender + '</td>';
                    row += '<td><a class="btn btn-primary"  onclick="GetbyId(' + item.id +')" >Edit</a> <a href="#" class="btn btn-danger" onclick="DeleteById(' + item.id + ')">Delete</a></td>';
                    row += '</tr>';
                });
                $("#tabledata").html(row);
            }

        },
        error: function () {
            console.log("no data ");
        }

    });
} 

function Add() {
    var data = {
        Name: $("#name").val(),
        Course: $("#course").val(),
        Gender:$('input[type="radio"]:checked').val()
    }
    console.log(data);
    $.ajax({
        url:"/Ajax/Add",
        type: "post",
        data: JSON.stringify(data), 
        datatype: 'json',
        contentType: 'application / json',
        success: function () {
              $("#name").val("");
              $("#course").val("");
            $('input[type="radio"]').prop('checked', false);
            $('#exampleModal').modal('hide');
            $('#idcol').css('display','none');
            DataInTable();
        },
        error :  function() {
            alert("Something are missing ");
        }

    });
}


function GetbyId(id) {
    $.ajax({
        url: "/Ajax/GetbyId/"+id,
        type: "Get",
        datatype: 'json',
        contentType: 'application / json',
        success: function (result) {
            $("#id").val(result.id);
            $("#name").val(result.name);
            $("#course").val(result.course);
            $(`input[type="radio"][value="${result.gender}"]`).prop('checked', true);
            $('#exampleModal').modal('show');
            $('#exampleModalLabel').text('Edit'); 
            $("#btnedit").css("display", "block");
            $("#btnsave").css("display", "none");
            $('#idcol').css('display', 'block');
        },
        error: function () {
            alert("Something are missing ");
        }
    });
}

function Edit() {
    var data = {
        Id: $("#id").val(),
        Name: $("#name").val(),
        Course: $("#course").val(),
        Gender: $('input[type="radio"]:checked').val()
    }
    $.ajax({
        url: '/Ajax/Edit',
        type: 'Post',
        data: JSON.stringify(data),
        contentType:'application/json',
        success: function() {
            $("#id").val('');
            $("#name").val('');
            $("#course").val('');
            $('input[type="radio"]').prop('checked', false);
            DataInTable();
            $('#exampleModal').modal('hide');
            $("#btnedit").css("display", "none");
            $("#btnsave").css("display", "block");

        },
        error: function (error) {
            alert("null");
        }
    });

}

function DeleteById(id) {
    $.ajax({
        url: "/Ajax/DeleteById/" + id,
        type: "post",
        datatype: 'json',
        contentType: 'application / json',
        success: function () {
            DataInTable();
        },
        error:function(){
            alert("Somthing rong")
        }


    });
}