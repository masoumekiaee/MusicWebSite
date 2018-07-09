$(function () {
    $('#slides').slidesjs({
        width: 940,
        height: 300,
        play: {
            active: true,
            auto: true,
            interval: 4000,
            swap: true
        }
    });

    $("#btnSendComment").on("click", function (event) {
        event.preventDefault();
        var btn = $(this);
        var SendcommentWrapper = btn.closest(".send-comment");
        var textbox = $(SendcommentWrapper.find("textarea"));
        var text = textbox.val();
        var musicId = $("#musicId").attr("data-musicid");

        btn.attr("disabled", true);
        textbox.attr("disabled", true);

        $.ajax({
            url: "/Comment/Send/",
            method: "POST",
            data: { text: text, musicId : musicId }
        }).done(function (data) {
            if (data.Success) {
                if (data.Inserted) {
                    btn.attr("disabled", false);
                    textbox.attr("disabled", false);
                    textbox.val("");
                    var commentsWrapper = $(".commentsWrapper");

                    var item = $("<div class='item'><div class='name'><span>" + data.FullName + "</span></div><div class='text'>" + data.Text + "</div></div>")

                    commentsWrapper.prepend(item);
                    alert("نظر شما ارسال شد.")
                }
            }
        }).fail(function () {

        });
    })

});