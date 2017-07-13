﻿// <copyright file="DefaultMetricsProvider.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using App.Metrics.Apdex;
using App.Metrics.Core.Apdex;
using App.Metrics.Core.Counter;
using App.Metrics.Core.Gauge;
using App.Metrics.Core.Histogram;
using App.Metrics.Core.Meter;
using App.Metrics.Core.Timer;
using App.Metrics.Counter;
using App.Metrics.Gauge;
using App.Metrics.Histogram;
using App.Metrics.Meter;
using App.Metrics.Registry;
using App.Metrics.Timer;

namespace App.Metrics.Core.Internal
{
    public sealed class DefaultMetricsProvider : IProvideMetrics
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DefaultMetricsProvider" /> class.
        /// </summary>
        /// <param name="registry">The metrics registry.</param>
        /// <param name="builderFactory">The buide factory.</param>
        /// <param name="clock">The clock.</param>
        public DefaultMetricsProvider(IMetricsRegistry registry, IBuildMetrics builderFactory, IClock clock)
        {
            Apdex = new DefaultApdexMetricProvider(builderFactory.Apdex, registry, clock);
            Counter = new DefaultCounterMetricProvider(builderFactory.Counter, registry);
            Gauge = new DefaultGaugeMetricProvider(builderFactory.Gauge, registry);
            Histogram = new DefaultHistogramMetricProvider(builderFactory.Histogram, registry);
            Meter = new DefaultMeterMetricProvider(builderFactory.Meter, registry, clock);
            Timer = new DefaultTimerMetricProvider(builderFactory.Timer, registry, clock);
        }

        /// <inheritdoc />
        public IProvideApdexMetrics Apdex { get; }

        /// <inheritdoc />
        public IProvideCounterMetrics Counter { get; }

        /// <inheritdoc />
        public IProvideGaugeMetrics Gauge { get; }

        /// <inheritdoc />
        public IProvideHistogramMetrics Histogram { get; }

        /// <inheritdoc />
        public IProvideMeterMetrics Meter { get; }

        /// <inheritdoc />
        public IProvideTimerMetrics Timer { get; }
    }
}