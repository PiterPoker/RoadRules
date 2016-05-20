$(document).ready(function() {

    $(".button-collapse").on("click", function() {
        event.stopPropagation();
        $(".mob-navigation").addClass("active");
    });

    $("html").click(function() {
        $(".mob-navigation").removeClass("active");
    });

    $(".mob-navigation").click(function(event) {
        event.stopPropagation();
    });

    var question1 = "<div class=\"question question-1\">" +
            "<div class=\"head\"><p><span>Вопрос: </span>содеражание вопроса.</p></div>" +
            "<div class=\"answers\">" +
            "<button type=\"submit\"><span>Ответ: </span>содеражание ответа.</button>" +
            "<button type=\"submit\"><span>Ответ: </span>содеражание ответа.</button>" +
            "<button type=\"submit\"><span>Ответ: </span>содеражание ответа.</button>" +
            "<button type=\"submit\"><span>Ответ: </span>содеражание ответа.</button>" +
            "</div></div>",
        question2 = "<div class=\"question question-2\">" +
            "<div class=\"head\"><p><span>Вопрос: </span>содеражание вопроса.</p></div>" +
            "<div class=\"answers\">" +
            "<div class=\"answer\"><input id=\"answer1\" type=\"checkbox\"/><label for=\"answer1\"><span>Ответ: </span>содеражание ответа.</label></div>" +
            "<div class=\"answer\"><input id=\"answer2\" type=\"checkbox\"/><label for=\"answer2\"><span>Ответ: </span>содеражание ответа.</label></div>" +
            "<div class=\"answer\"><input id=\"answer3\" type=\"checkbox\"/><label for=\"answer3\"><span>Ответ: </span>содеражание ответа.</label></div>" +
            "<div class=\"answer\"><input id=\"answer4\" type=\"checkbox\"/><label for=\"answer4\"><span>Ответ: </span>содеражание ответа.</label></div>" +
            "</div>" +
            "<div class=\"answer-button\"><input type=\"submit\" value=\"Ответить\"></div></div>",
        question3 = "<div class=\"question question-3\">" +
            "<div class=\"head\"><p><span>Вопрос: </span>содеражание вопроса.</p></div>" +
            "<div class=\"answer input-answer\"><label for=\"answer5\"><span>Ответ: </span></label><input id=\"answer5\" type=\"text\" placeholder=\"Введите ответ\"/></div>" +
            "<div class=\"answer-button\"><input type=\"submit\" value=\"Ответить\"></div></div>",
        emptyElement = "";

    var questionArray = [question1, question2, question3, question2, question3, question1, emptyElement],
        i = 0;
    $(".content").prepend(questionArray[i]);

    $("html").on("click", ".answers button, .answer-button input[type=submit]", function() {
        if (i <= 6) {
            $(".question").remove();
            $(".content").prepend(questionArray[++i]);
            $("#progress-bar").val(i);
            $("span.value").text(i);
        }
    });
});