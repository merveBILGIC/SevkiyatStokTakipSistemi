

$(() => {
    LoadProdData();
    var connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();
    connection.on("LoadProducts", function(){

        LoadProdData();


    })

    LoadProdData();
    function LoadProdData() {

        var tr = '';

        $.ajax({
            url: '/Siparis/GetProducts',
            method: 'GET',
            success:(result)=>{

                 $.each(result, (k, v) => {

                     tr += `<tr>
                        <td>${v.FirmaAdı}</td>
                        <td>${v.SiparisTarihi}</td>
                        <td>${v.Urun}</td>
                        <td>${v.TeslimTarihi}</td>
                       
                         
                   </tr> `
                 })
                $("#tableBody").html(tr);

            },
            error: (error) => {
                console.log(error)
            }


         });  

    } 

})