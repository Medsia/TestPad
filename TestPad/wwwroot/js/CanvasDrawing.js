let total_value = 100;

function renderPieChart(canvasId, scorePercent) {
    let chartCanvas = document.getElementById(canvasId);
    chartCanvas.width = 300;
    chartCanvas.height = 300;
    let ctx = chartCanvas.getContext("2d");

    let pieRadius = Math.min(chartCanvas.width / 2, chartCanvas.height / 2);
    pieRadius -= pieRadius / 10;
    let centerX = chartCanvas.width / 2;
    let centerY = chartCanvas.height / 2;

    let correctAnswersColor = '#508c36';
    let wrongAnswersColor = '#ef891f';

    let fillPoint = 2 * Math.PI;

    let angle = (2 * Math.PI * scorePercent) / total_value;
    drawPieSlice(ctx, centerX, centerY, pieRadius, 0, angle, correctAnswersColor);
    drawPieSlice(ctx, centerX, centerY, pieRadius, angle, fillPoint, wrongAnswersColor);

    drawPieSlice(ctx, centerX, centerY, (pieRadius * 0.5), 0, fillPoint, 'white');
    drawSlicePercentage(chartCanvas, ctx, scorePercent);
}


function drawPieSlice(ctx, centerX, centerY, radius, startAngle, endAngle, color) {
    ctx.fillStyle = color;
    ctx.beginPath();
    ctx.moveTo(centerX, centerY);
    ctx.arc(centerX, centerY, radius, startAngle, endAngle);
    ctx.closePath();
    ctx.fill();
}


function drawSlicePercentage(canvas, ctx, percent) {
    let labelText = percent + "%";

    let offset = labelText.length;
    let labelX = canvas.width / 2 - (offset * 8);
    let labelY = canvas.height / 2 + 10;

    ctx.fillStyle = "black";
    ctx.font = "bold 30px Arial";
    ctx.fillText(labelText, labelX, labelY);
}