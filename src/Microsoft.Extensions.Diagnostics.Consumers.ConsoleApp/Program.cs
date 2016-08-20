﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Diagnostics.HealthReporters;
using Microsoft.Extensions.Diagnostics.Inputs;
using Microsoft.Extensions.Diagnostics.Outputs;

namespace Microsoft.Extensions.Diagnostics.Consumers.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // HealthReporter
            using (IHealthReporter reporter = new CsvFileHealthReporter("HealthReport.csv", HealthReportLevel.Message))
            {
                // Inputs
                List<IObservable<EventData>> inputs = new List<IObservable<EventData>>();
                inputs.Add(new TraceInput(reporter));

                // Senders
                List<EventDataSender> outputs = new List<EventDataSender>();
                outputs.Add(new StdSender(reporter));

                DiagnosticsPipeline pipeline = new DiagnosticsPipeline(reporter, inputs,
                    new EventSink<EventData>[] {
                    new EventSink<EventData>(new StdSender(reporter), null)
                });

                // Build up the pipeline
                Console.WriteLine("Pipeline is created.");

                // Send a trace to the pipeline
                Trace.TraceInformation("This is a message from trace . . .");

                // Check the result
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey(true);
            }
        }
    }
}