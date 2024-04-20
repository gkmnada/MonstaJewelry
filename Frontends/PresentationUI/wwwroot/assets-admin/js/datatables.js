$(function (e) {
    $('#datatable-basic').DataTable({
        responsive: true,
        autoWidth: false,
        language: {
            searchPlaceholder: 'Ara...',
            sSearch: '',
            paginate: {
                previous: "&Ouml;nceki",
                next: "Sonraki"
            },
            emptyTable: "Kay&inodot;t Bulunamad&inodot;",
            lengthMenu: "Her sayfada _MENU_ kay&inodot;t g&ouml;ster",
            info: "Toplam _TOTAL_ kay&inodot;ttan _START_ ile _END_ aras&inodot; g&ouml;steriliyor",
            infoFiltered: "Toplam _MAX_ kay&inodot;ttan filtreleniyor",
            infoEmpty: "Toplam 0 kay&inodot;ttan 0 ile 0 aras&inodot; g&ouml;steriliyor",
        },
        "pageLength": 50,
        "order": [],
        //scrollX: true
    });

    $('#datatable-basic-file').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'csv', 'excel', 'pdf', {
                extend: 'print',
                text: 'Yazd&inodot;r'
            },
        ],
        responsive: true,
        autoWidth: false,
        language: {
            searchPlaceholder: 'Ara...',
            sSearch: '',
            paginate: {
                previous: "&Ouml;nceki",
                next: "Sonraki"
            },
            emptyTable: "Kay&inodot;t Bulunamad&inodot;",
            lengthMenu: "Her sayfada _MENU_ kay&inodot;t g&ouml;ster",
            info: "Toplam _TOTAL_ kay&inodot;ttan _START_ ile _END_ aras&inodot; g&ouml;steriliyor",
            infoFiltered: "Toplam _MAX_ kay&inodot;ttan filtreleniyor",
            infoEmpty: "Toplam 0 kay&inodot;ttan 0 ile 0 aras&inodot; g&ouml;steriliyor",
        },
        "pageLength": 50,
        "order": [],
        //scrollX: true
    });

    $('#responsiveDataTable').DataTable({
        responsive: true,
        language: {
            searchPlaceholder: 'Ara...',
            sSearch: '',
            paginate: {
                previous: "&Ouml;nceki",
                next: "Sonraki"
            },
            lengthMenu: "Her sayfada _MENU_ kay&inodot;t g&ouml;ster",
            info: "Toplam _TOTAL_ kay&inodot;ttan _START_ ile _END_ aras&inodot; g&ouml;steriliyor"
        },
        "pageLength": 10,
    });

    $('#responsivemodal-DataTable').DataTable({
        responsive: {
            details: {
                display: $.fn.dataTable.Responsive.display.modal({
                    header: function (row) {
                        var data = row.data();
                        return data[0] + ' ' + data[1];
                    }
                }),
                renderer: $.fn.dataTable.Responsive.renderer.tableAll({
                    tableClass: 'table'
                })
            }
        },
        language: {
            searchPlaceholder: 'Search...',
            sSearch: '',
        },
        "pageLength": 10,
    });

    $('#file-export').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        language: {
            searchPlaceholder: 'Search...',
            sSearch: '',
        },
    });

    var table = $('#delete-datatable').DataTable({
        language: {
            searchPlaceholder: 'Search...',
            sSearch: '',
        }
    });
    $('#delete-datatable tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            table.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });
    $('#button').on("click", function () {
        table.row('.selected').remove().draw(false);
    });

    $('#scroll-vertical').DataTable({
        scrollY: '265px',
        scrollCollapse: true,
        paging: false,
        scrollX: true,
        language: {
            searchPlaceholder: 'Search...',
            sSearch: '',
        },
    });

    $('#hidden-columns').DataTable({
        columnDefs: [
            {
                target: 2,
                visible: false,
                searchable: false,
            },
            {
                target: 3,
                visible: false,
            },
        ],
        language: {
            searchPlaceholder: 'Search...',
            sSearch: '',
        },
        "pageLength": 10,
        // scrollX: true
    });

    var t = $('#add-row').DataTable({

        language: {
            searchPlaceholder: 'Search...',
            sSearch: '',
        },
    });
    var counter = 1;
    $('#addRow').on('click', function () {
        t.row.add([counter + '.1', counter + '.2', counter + '.3', counter + '.4', counter + '.5']).draw(false);
        counter++;
    });
});
