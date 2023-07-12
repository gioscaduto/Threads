using WaitPulse.App;

BufferExample buffer = new(qtdProducers: 10, qtdConsumers: 10);

buffer.StartThreads();