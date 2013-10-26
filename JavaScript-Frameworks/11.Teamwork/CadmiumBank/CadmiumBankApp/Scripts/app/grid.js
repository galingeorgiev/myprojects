$(document).ready(function () {

    var kmodel = new kendo.observable({
        iban: { type: "number" },
        id: { type: "number" },

        details: function () {
            console.log("firstName");
        }
    });

    var dmodel = kendo.data.Model.define({
        fields: {
            Id: { editable: false, type: "number" },
            Type: { editable: false, type: "string" },
        }
    });

    $("#grid").kendoGrid({
        dataSource: {

            transport: {
                read: {
                    url: "http://localhost:53190/api/accounts",

                    dataType: "json",

                    contentType: "application/json",
                    beforeSend: function (xhr) { xhr.setRequestHeader('X-SessionKey', '2rmaLcLlOXDAzAyFatuBRKqJtyumAkUMyjfTwpsjaPagghINJj'); },
                },
            },
            batch: true,
            schema: {
                model: dmodel
            }
        },
        sortable: true,
        pageable: {
            refresh: true,
            pageSizes: true
        },
        columns: [{
            field: "id",
            width: 90,
            title: "Id Name"
        },
        {
            field: "accountType.Name",
            width: 90,
            title: "type Name"
        },

        {
            command: [
                        { name: "details", click: kmodel.details, text: "Details" },
                        { name: "transfer", text: "Transfer" }
                     ],
            title: "Commands"
        }]

    });
});