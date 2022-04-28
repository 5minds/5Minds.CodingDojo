package com.github.irgend42.weirdchess.service;

import lombok.val;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.junit.jupiter.MockitoExtension;

import java.util.List;
import java.util.Random;
import java.util.stream.Stream;

import static org.junit.jupiter.api.Assertions.assertEquals;

@ExtendWith(MockitoExtension.class)
class WeirdChessServiceTest {
    @InjectMocks
    private SimpleChessService chessService;

    @Test
    void testCalculatePaneWithExampleData1(){
        val columnSizes = List.of(3, 1, 2, 7, 1);
        val rowSizes = List.of(1, 8, 4, 5, 2);

        Integer[] result = chessService.calculatePane(columnSizes, rowSizes);

        assertEquals(2, result.length);
        assertEquals(146, result[0]);
        assertEquals(134, result[1]);
    }

    @Test
    void testCalculatePaneWithExampleData2(){
        val columnSizes = List.of(3, 1, 2, 7, 1, 11, 12, 3, 8, 1);
        val rowSizes = List.of(1, 8, 4, 5, 2, 21, 5, 2, 2, 17);

        Integer[] result = chessService.calculatePane(columnSizes, rowSizes);

        assertEquals(2, result.length);
        assertEquals(1583, result[0]);
        assertEquals(1700, result[1]);
    }


    @Test
    void testCalculatePaneWithExampleData3(){
        val columnSizes = List.of(3);
        val rowSizes = List.of(2);

        Integer[] result = chessService.calculatePane(columnSizes, rowSizes);

        assertEquals(2, result.length);
        assertEquals(6, result[0]);
        assertEquals(0, result[1]);
    }


    @Test
    void testCalculatePaneWithNoColums(){
        Random random = new Random(42);
        val columnSizes = List.<Integer>of();
        val rowSizes = Stream.generate(() -> random.nextInt(13)).limit(100).toList();

        Integer[] result = chessService.calculatePane(columnSizes, rowSizes);

        assertEquals(2, result.length);
        assertEquals(0, result[0]);
        assertEquals(0, result[0]);
    }


}
