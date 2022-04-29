package com.github.irgend42.weirdchess.service;

import lombok.val;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.MethodSource;


import java.util.List;
import java.util.Random;
import java.util.stream.Stream;

import static org.junit.jupiter.api.Assertions.assertEquals;

class WeirdChessServiceTest {
    public static Stream<WeirdChessService> getServices() {
        return Stream.of(new SimpleChessService(), new FastChessService());
    }

    @ParameterizedTest
    @MethodSource("getServices")
    void testCalculatePaneWithExampleData1(WeirdChessService chessService){
        val columnSizes = List.of(3, 1, 2, 7, 1);
        val rowSizes = List.of(1, 8, 4, 5, 2);

        Long[] result = chessService.calculatePane(columnSizes, rowSizes);

        assertEquals(2, result.length);
        assertEquals(146, result[0]);
        assertEquals(134, result[1]);
    }

    @ParameterizedTest
    @MethodSource("getServices")
    void testCalculatePaneWithExampleData2(WeirdChessService chessService){
        val columnSizes = List.of(3, 1, 2, 7, 1, 11, 12, 3, 8, 1);
        val rowSizes = List.of(1, 8, 4, 5, 2, 21, 5, 2, 2, 17);

        Long[] result = chessService.calculatePane(columnSizes, rowSizes);

        assertEquals(2, result.length);
        assertEquals(1583, result[0]);
        assertEquals(1700, result[1]);
    }


    @ParameterizedTest
    @MethodSource("getServices")
    void testCalculatePaneWithExampleData3(WeirdChessService chessService){
        val columnSizes = List.of(3);
        val rowSizes = List.of(2);

        Long[] result = chessService.calculatePane(columnSizes, rowSizes);

        assertEquals(2, result.length);
        assertEquals(6, result[0]);
        assertEquals(0, result[1]);
    }


    @ParameterizedTest
    @MethodSource("getServices")
    void testCalculatePaneWithNoColums(WeirdChessService chessService){
        Random random = new Random(42);
        val columnSizes = List.<Integer>of();
        val rowSizes = Stream.generate(() -> random.nextInt(13)).limit(100).toList();

        Long[] result = chessService.calculatePane(columnSizes, rowSizes);

        assertEquals(2, result.length);
        assertEquals(0, result[0]);
        assertEquals(0, result[0]);
    }
}
