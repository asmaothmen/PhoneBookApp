$(document).ready(function () {


    contactsTable = new DataTable('#contactsTable', {
        layout: {
            bottomEnd: {
                paging: {
                    boundaryNumbers: false
                }
            }
        },
       
        order: [[0, 'desc']] 
    });
});
function deleteContact(e) {
    swal({
        title: 'Are you sure ?',
        text: "Once deleted, you can't return it back" ,
        icon: "warning",
        buttons: {
            cancel: {
                text:'Cancel' ,
                value: null,
                visible: true,
                closeModal: true,
            },
            confirm: {
                text: 'OK' ,
                value: true,
                visible: true,
                className: "",
                closeModal: true
            }
        }
    }).then((willDelete) => {
        if (willDelete) {
           
            $("#delete-" + e).submit();
        }
    });
}
