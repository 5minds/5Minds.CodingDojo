package com.awx.tasks.services;

import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertTrue;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest
public class PalindromServiceTest {
    
    @Autowired
    private PalindromService palindromService;

    @Test
    public void testCasesForWords() {        
        assertTrue(palindromService.checkText("Abba"));
        assertTrue(palindromService.checkText("Lagerregal"));
        assertTrue(palindromService.checkText("Reliefpfeiler"));
        assertTrue(palindromService.checkText("Dienstmannamtsneid"));
        assertFalse(palindromService.checkText("Test"));
    }
    
    @Test
    public void testCasesForSentences() {      
        assertTrue(palindromService.checkText("Tarne nie deinen Rat!"));
        assertTrue(palindromService.checkText("Eine güldne, gute Tugend: Lüge nie!"));
        assertTrue(palindromService.checkText("Ein agiler Hit reizt sie. Geist?! Biertrunk nur treibt sie. Geist ziert ihre Liga nie!"));
        assertFalse(palindromService.checkText("Dies ist ein Test"));
    }
}