package com.github.irgend42.weirdchess.service;


import lombok.val;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class FastChessService implements WeirdChessService{
    @Override
    public Long[] calculatePane(List<Integer> columnSizes, List<Integer> rowSizes) {
        val evenOddTotalWidth = new int[]{0, 0};
        for (int i = 0; i < columnSizes.size(); i++) {
            evenOddTotalWidth[i%2] += columnSizes.get(i);
        }

        Long[] whiteBlackTotalPane = new Long[]{0L, 0L};
        for (int i = 0; i < whiteBlackTotalPane.length; i++) {
            for (int j = 0; j < rowSizes.size(); j++) {
                whiteBlackTotalPane[(i+j)%2] += (long) evenOddTotalWidth[i] * rowSizes.get(j);
            }
        }
        return whiteBlackTotalPane;
    }
}
