import React, { useEffect, useRef } from 'react';
import Chart from 'chart.js/auto';

const LineGraph = ({ data }) => {
  const chartRef = useRef(null);

  useEffect(() => {
    // Create the chart instance
    const ctx = chartRef.current.getContext('2d');

    // Create the chart
    new Chart(ctx, {
      type: 'line',
      data: {
        labels: data.labels, // Array of labels for x-axis
        datasets: [
          {
            label: 'Line Graph',
            data: data.values, // Array of values for y-axis
            borderColor: 'rgba(75, 192, 192, 1)', // Color of the line
            backgroundColor: 'rgba(75, 192, 192, 0.2)', // Color of the area under the line
            borderWidth: 1,
          },
        ],
      },
      options: {
        responsive: true,
        scales: {
          x: {
            display: true,
            title: {
              display: true,
              text: 'X-axis Label',
            },
          },
          y: {
            display: true,
            title: {
              display: true,
              text: 'Y-axis Label',
            },
          },
        },
      },
    });
  }, [data]);

  return <canvas ref={chartRef} />;
};

export default LineGraph;