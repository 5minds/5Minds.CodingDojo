package com.github.irgend42.weirdchess.service;

import org.openjdk.jmh.Main;
import org.openjdk.jmh.annotations.*;
import org.openjdk.jmh.infra.Blackhole;

import java.io.IOException;
import java.util.List;
import java.util.Random;
import java.util.stream.Stream;

public class WeirdChessServiceBenchmark {
    @State(Scope.Thread)
    public static class ChessState {
        public List<Integer> rs;
        public List<Integer> cs;
        public WeirdChessService chessService;

        @Param({"simple", "fast"})
        private String serviceType;

        // Be warned: SimpleChessService runtime scales in O(n²)
        // 10-times the fieldSize will result in approximately 100-times the runtime.
        @Param({"1", "10", "100", "1000", "10000", "100000", /*"1000000", "10000000", "100000000", "1000000000"*/})
        private int fieldSize;

        @Setup(Level.Invocation)
        public void setup(){
            chessService = switch(serviceType){
                case "simple" -> new SimpleChessService();
                case "fast" -> new FastChessService();
                default -> throw new IllegalStateException();
            };

            Random random = new Random(fieldSize);
            rs = Stream.generate(() -> random.nextInt(10)).limit(fieldSize).toList();
            cs = Stream.generate(() -> random.nextInt(10)).limit(fieldSize).toList();

        }
    }

    @Benchmark
    @Threads(4)
    @Fork(value = 5, warmups = 1)
    @BenchmarkMode(Mode.SingleShotTime)
    public void benchChessService(Blackhole blackhole, ChessState state){
        blackhole.consume(state.chessService.calculatePane(state.cs, state.rs));
    }

    public static void main(String[] args) throws IOException {
        Main.main(args);
    }
}
