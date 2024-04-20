(function () {
  "use strict";

  /* Bitcoin Chart */
  var element = document.getElementById("btc-chart1");
  if (element !== null) {
    var spark1 = {
      chart: {
        type: "line",
        height: 30,
        width: 120,
        sparkline: {
          enabled: true,
        },
        dropShadow: {
          enabled: true,
          enabledOnSeries: undefined,
          top: 0,
          left: 0,
          blur: 3,
          color: "#000",
          opacity: 0.1,
        },
      },
      stroke: {
        show: true,
        curve: "smooth",
        lineCap: "butt",
        colors: undefined,
        width: 1.5,
        dashArray: 0,
      },
      fill: {
        gradient: {
          enabled: false,
        },
      },
      series: [
        {
          name: "Value",
          data: [
            0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51,
            35, 41, 35, 27, 93, 53, 61, 27, 54, 43, 19, 46, 0, 45, 54, 38, 56, 24,
            65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53, 61, 27, 54, 43, 19,
            46,
          ],
        },
      ],
      yaxis: {
        min: 0,
        show: false,
      },
      xaxis: {
        axisBorder: {
          show: false,
        },
      },
      yaxis: {
        axisBorder: {
          show: false,
        },
      },
      tooltip: {
        enabled: false,
      },
      colors: ["rgb(230, 83, 60)"],
    };
    var spark1 = new ApexCharts(document.querySelector("#btc-chart1"), spark1);
    spark1.render();
  }

  /* Etherium Chart */
  var element = document.getElementById("eth-chart1");
  if (element !== null) {
    var spark2 = {
      chart: {
        type: "line",
        height: 30,
        width: 120,
        sparkline: {
          enabled: true,
        },
        dropShadow: {
          enabled: true,
          enabledOnSeries: undefined,
          top: 0,
          left: 0,
          blur: 3,
          color: "#000",
          opacity: 0.1,
        },
      },
      stroke: {
        show: true,
        curve: "smooth",
        lineCap: "butt",
        colors: undefined,
        width: 1.5,
        dashArray: 0,
      },
      fill: {
        gradient: {
          enabled: false,
        },
      },
      series: [
        {
          name: "Value",
          data: [
            0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51,
            35, 41, 35, 27, 93, 53, 61, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 93, 53, 61, 27, 54, 43, 19,
            46,
          ],
        },
      ],
      yaxis: {
        min: 0,
        show: false,
      },
      xaxis: {
        axisBorder: {
          show: false,
        },
      },
      yaxis: {
        axisBorder: {
          show: false,
        },
      },
      tooltip: {
        enabled: false,
      },
      colors: ["rgb(38, 191, 148)"],
    };
    var spark2 = new ApexCharts(document.querySelector("#eth-chart1"), spark2);
    spark2.render();
  }

  /* Golem Chart */
  var element = document.getElementById("glm-chart");
  if (element !== null) {
    var spark3 = {
      chart: {
        type: "line",
        height: 30,
        width: 120,
        sparkline: {
          enabled: true,
        },
        dropShadow: {
          enabled: true,
          enabledOnSeries: undefined,
          top: 0,
          left: 0,
          blur: 3,
          color: "#000",
          opacity: 0.1,
        },
      },
      stroke: {
        show: true,
        curve: "smooth",
        lineCap: "butt",
        colors: undefined,
        width: 1.5,
        dashArray: 0,
      },
      fill: {
        gradient: {
          enabled: false,
        },
      },
      series: [
        {
          name: "Value",
          data: [
            0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51,
            35, 41, 35, 27, 93, 53, 61, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 93, 53, 61, 27, 54, 43, 19,
            46,
          ],
        },
      ],
      yaxis: {
        min: 0,
        show: false,
      },
      xaxis: {
        axisBorder: {
          show: false,
        },
      },
      yaxis: {
        axisBorder: {
          show: false,
        },
      },
      tooltip: {
        enabled: false,
      },
      colors: ["rgb(38, 191, 148)"],
    };
    var spark3 = new ApexCharts(document.querySelector("#glm-chart"), spark3);
    spark3.render();
  }

  /* Dash Chart */
  var element = document.getElementById("dash-chart1");
  if (element !== null) {
    var spark4 = {
      chart: {
        type: "line",
        height: 30,
        width: 120,
        sparkline: {
          enabled: true,
        },
        dropShadow: {
          enabled: true,
          enabledOnSeries: undefined,
          top: 0,
          left: 0,
          blur: 3,
          color: "#000",
          opacity: 0.1,
        },
      },
      stroke: {
        show: true,
        curve: "smooth",
        lineCap: "butt",
        colors: undefined,
        width: 1.5,
        dashArray: 0,
      },
      fill: {
        gradient: {
          enabled: false,
        },
      },
      series: [
        {
          name: "Value",
          data: [
            0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51,
            35, 41, 35, 27, 93, 53, 61, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 93, 53, 61, 27, 54, 43, 19,
            46,
          ],
        },
      ],
      yaxis: {
        min: 0,
        show: false,
      },
      xaxis: {
        axisBorder: {
          show: false,
        },
      },
      yaxis: {
        axisBorder: {
          show: false,
        },
      },
      tooltip: {
        enabled: false,
      },
      colors: ["rgb(38, 191, 148)"],
    };
    var spark4 = new ApexCharts(document.querySelector("#dash-chart1"), spark4);
    spark4.render();
  }

  /* Litecoin Chart */
  var element = document.getElementById("lite-chart");
  if (element !== null) {
    var spark5 = {
      chart: {
        type: "line",
        height: 30,
        width: 120,
        sparkline: {
          enabled: true,
        },
        dropShadow: {
          enabled: true,
          enabledOnSeries: undefined,
          top: 0,
          left: 0,
          blur: 3,
          color: "#000",
          opacity: 0.1,
        },
      },
      stroke: {
        show: true,
        curve: "smooth",
        lineCap: "butt",
        colors: undefined,
        width: 1.5,
        dashArray: 0,
      },
      fill: {
        gradient: {
          enabled: false,
        },
      },
      series: [
        {
          name: "Value",
          data: [
            0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51,
            35, 41, 35, 27, 93, 53, 61, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 93, 53, 61, 27, 54, 43, 19,
            46,
          ],
        },
      ],
      yaxis: {
        min: 0,
        show: false,
      },
      xaxis: {
        axisBorder: {
          show: false,
        },
      },
      yaxis: {
        axisBorder: {
          show: false,
        },
      },
      tooltip: {
        enabled: false,
      },
      colors: ["rgb(230, 83, 60)"],
    };
    var spark5 = new ApexCharts(document.querySelector("#lite-chart"), spark5);
    spark5.render();
  }
  /* Ripple Chart */
  var element = document.getElementById("ripple-chart");
  if (element !== null) {
    var spark6 = {
      chart: {
        type: "line",
        height: 30,
        width: 120,
        sparkline: {
          enabled: true,
        },
        dropShadow: {
          enabled: true,
          enabledOnSeries: undefined,
          top: 0,
          left: 0,
          blur: 3,
          color: "#000",
          opacity: 0.1,
        },
      },
      stroke: {
        show: true,
        curve: "smooth",
        lineCap: "butt",
        colors: undefined,
        width: 1.5,
        dashArray: 0,
      },
      fill: {
        gradient: {
          enabled: false,
        },
      },
      series: [
        {
          name: "Value",
          data: [
            0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51,
            35, 41, 35, 27, 93, 53, 61, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 93, 53, 61, 27, 54, 43, 19,
            46,
          ],
        },
      ],
      yaxis: {
        min: 0,
        show: false,
      },
      xaxis: {
        axisBorder: {
          show: false,
        },
      },
      yaxis: {
        axisBorder: {
          show: false,
        },
      },
      tooltip: {
        enabled: false,
      },
      colors: ["rgb(38, 191, 148)"],
    };
    var spark6 = new ApexCharts(document.querySelector("#ripple-chart"), spark6);
    spark6.render();
  }

  /* Eos Chart */
  var element = document.getElementById("eos-chart");
  if (element !== null) {
    var spark7 = {
      chart: {
        type: "line",
        height: 30,
        width: 120,
        sparkline: {
          enabled: true,
        },
        dropShadow: {
          enabled: true,
          enabledOnSeries: undefined,
          top: 0,
          left: 0,
          blur: 3,
          color: "#000",
          opacity: 0.1,
        },
      },
      stroke: {
        show: true,
        curve: "smooth",
        lineCap: "butt",
        colors: undefined,
        width: 1.5,
        dashArray: 0,
      },
      fill: {
        gradient: {
          enabled: false,
        },
      },
      series: [
        {
          name: "Value",
          data: [
            0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51,
            35, 41, 35, 27, 93, 53, 61, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 93, 53, 61, 27, 54, 43, 19,
            46,
          ],
        },
      ],
      yaxis: {
        min: 0,
        show: false,
      },
      xaxis: {
        axisBorder: {
          show: false,
        },
      },
      yaxis: {
        axisBorder: {
          show: false,
        },
      },
      tooltip: {
        enabled: false,
      },
      colors: ["rgb(38, 191, 148)"],
    };
    var spark7 = new ApexCharts(document.querySelector("#eos-chart"), spark7);
    spark7.render();
  }

  /* Bytecoin Chart */
  var element = document.getElementById("bytecoin-chart");
  if (element !== null) {
    var spark8 = {
      chart: {
        type: "line",
        height: 30,
        width: 120,
        sparkline: {
          enabled: true,
        },
        dropShadow: {
          enabled: true,
          enabledOnSeries: undefined,
          top: 0,
          left: 0,
          blur: 3,
          color: "#000",
          opacity: 0.1,
        },
      },
      stroke: {
        show: true,
        curve: "smooth",
        lineCap: "butt",
        colors: undefined,
        width: 1.5,
        dashArray: 0,
      },
      fill: {
        gradient: {
          enabled: false,
        },
      },
      series: [
        {
          name: "Value",
          data: [
            0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51,
            35, 41, 35, 27, 93, 53, 61, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 93, 53, 61, 27, 54, 43, 19,
            46,
          ],
        },
      ],
      yaxis: {
        min: 0,
        show: false,
      },
      xaxis: {
        axisBorder: {
          show: false,
        },
      },
      yaxis: {
        axisBorder: {
          show: false,
        },
      },
      tooltip: {
        enabled: false,
      },
      colors: ["rgb(230, 83, 60)"],
    };
    var spark8 = new ApexCharts(document.querySelector("#bytecoin-chart"), spark8);
    spark8.render();
  }

  /* IOTA Chart */
  var element = document.getElementById("iota-chart");
  if (element !== null) {
    var spark9 = {
      chart: {
        type: "line",
        height: 30,
        width: 120,
        sparkline: {
          enabled: true,
        },
        dropShadow: {
          enabled: true,
          enabledOnSeries: undefined,
          top: 0,
          left: 0,
          blur: 3,
          color: "#000",
          opacity: 0.1,
        },
      },
      stroke: {
        show: true,
        curve: "smooth",
        lineCap: "butt",
        colors: undefined,
        width: 1.5,
        dashArray: 0,
      },
      fill: {
        gradient: {
          enabled: false,
        },
      },
      series: [
        {
          name: "Value",
          data: [
            0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51,
            35, 41, 35, 27, 93, 53, 61, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 93, 53, 61, 27, 54, 43, 19,
            46,
          ],
        },
      ],
      yaxis: {
        min: 0,
        show: false,
      },
      xaxis: {
        axisBorder: {
          show: false,
        },
      },
      yaxis: {
        axisBorder: {
          show: false,
        },
      },
      tooltip: {
        enabled: false,
      },
      colors: ["rgb(230, 83, 60)"],
    };
    var spark9 = new ApexCharts(document.querySelector("#iota-chart"), spark9);
    spark9.render();
  }

  /* Monero Chart */
  var element = document.getElementById("monero-chart");
  if (element !== null) {
    var spark10 = {
      chart: {
        type: "line",
        height: 30,
        width: 120,
        sparkline: {
          enabled: true,
        },
        dropShadow: {
          enabled: true,
          enabledOnSeries: undefined,
          top: 0,
          left: 0,
          blur: 3,
          color: "#000",
          opacity: 0.1,
        },
      },
      stroke: {
        show: true,
        curve: "smooth",
        lineCap: "butt",
        colors: undefined,
        width: 1.5,
        dashArray: 0,
      },
      fill: {
        gradient: {
          enabled: false,
        },
      },
      series: [
        {
          name: "Value",
          data: [
            0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51,
            35, 41, 35, 27, 93, 53, 61, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53,
            61, 27, 54, 43, 19, 46, 0, 45, 54, 93, 53, 61, 27, 54, 43, 19,
            46,
          ],
        },
      ],
      yaxis: {
        min: 0,
        show: false,
      },
      xaxis: {
        axisBorder: {
          show: false,
        },
      },
      yaxis: {
        axisBorder: {
          show: false,
        },
      },
      tooltip: {
        enabled: false,
      },
      colors: ["rgb(38, 191, 148)"],
    };
    var spark10 = new ApexCharts(document.querySelector("#monero-chart"), spark10);
    spark10.render();
  }

  /* Start:: Main cards charts */
  var element = document.getElementById("bitcoin-chart");
  if (element !== null) {
    var spark1 = {
      chart: {
        type: 'line',
        height: 40,
        width: 120,
        sparkline: {
          enabled: true
        },
        dropShadow: {
          enabled: true,
          enabledOnSeries: undefined,
          top: 0,
          left: 0,
          blur: 3,
          color: '#000',
          opacity: 0.1
        }
      },
      stroke: {
        show: true,
        curve: 'smooth',
        lineCap: 'butt',
        colors: undefined,
        width: 1.5,
        dashArray: 0,
      },
      fill: {
        gradient: {
          enabled: false
        }
      },
      series: [{
        name: 'Value',
        data: [0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53, 61, 27, 54, 43, 19, 46]
      }],
      yaxis: {
        min: 0,
        show: false
      },
      xaxis: {
        axisBorder: {
          show: false
        },
      },
      yaxis: {
        axisBorder: {
          show: false
        },
      },
      colors: ['#26bf94'],

    }
    var spark1 = new ApexCharts(document.querySelector("#bitcoin-chart"), spark1);
    spark1.render();
  }

  var element = document.getElementById("etherium-chart");
  if (element !== null) {
    var spark2 = {
      chart: {
        type: 'line',
        height: 40,
        width: 120,
        sparkline: {
          enabled: true
        },
        dropShadow: {
          enabled: true,
          enabledOnSeries: undefined,
          top: 0,
          left: 0,
          blur: 3,
          color: '#000',
          opacity: 0.1
        }
      },
      stroke: {
        show: true,
        curve: 'smooth',
        lineCap: 'butt',
        colors: undefined,
        width: 1.5,
        dashArray: 0,
      },
      fill: {
        gradient: {
          enabled: false
        }
      },
      series: [{
        name: 'Value',
        data: [0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53, 61, 27, 54, 43, 19, 46]
      }],
      yaxis: {
        min: 0,
        show: false
      },
      xaxis: {
        axisBorder: {
          show: false
        },
      },
      yaxis: {
        axisBorder: {
          show: false
        },
      },
      colors: ['#26bf94'],

    }
    var spark2 = new ApexCharts(document.querySelector("#etherium-chart"), spark2);
    spark2.render();
  }

  var element = document.getElementById("dashcoin-chart");
  if (element !== null) {
    var spark3 = {
      chart: {
        type: 'line',
        height: 40,
        width: 120,
        sparkline: {
          enabled: true
        },
        dropShadow: {
          enabled: true,
          enabledOnSeries: undefined,
          top: 0,
          left: 0,
          blur: 3,
          color: '#000',
          opacity: 0.1
        }
      },
      stroke: {
        show: true,
        curve: 'smooth',
        lineCap: 'butt',
        colors: undefined,
        width: 1.5,
        dashArray: 0,
      },
      fill: {
        gradient: {
          enabled: false
        }
      },
      series: [{
        name: 'Value',
        data: [0, 45, 54, 38, 56, 24, 65, 31, 37, 39, 62, 51, 35, 41, 35, 27, 93, 53, 61, 27, 54, 43, 19, 46]
      }],
      yaxis: {
        min: 0,
        show: false
      },
      xaxis: {
        axisBorder: {
          show: false
        },
      },
      yaxis: {
        axisBorder: {
          show: false
        },
      },
      colors: ['#e6533c'],

    }
    var spark3 = new ApexCharts(document.querySelector("#dashcoin-chart"), spark3);
    spark3.render();
  }
  /* End:: Main cards charts */

})();
