
#define _XOPEN_SOURCE 500

#include <cs50.h>
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

#define DIM_MIN 1
#define DIM_MAX 100

int board[DIM_MAX][DIM_MAX];

int d;
int movecount;
int moves;
int prevTile;
int direction;

void clear(void);
void greet(void);
void init(void);
void draw(void);
bool move(void);
bool done(void);

int main(int argc, string argv[])
{
    if (argc != 3)
    {
        printf("Usage: ant length movecount\n");
        return 1;
    }

    d = atoi(argv[1]);
    if (d < DIM_MIN || d > DIM_MAX)
    {
        printf("Board must be between %i x %i and %i x %i, inclusive.\n",
            DIM_MIN, DIM_MIN, DIM_MAX, DIM_MAX);
        return 2;
    }
    
    movecount = atoi(argv[2]);
    moves = 0;
    prevTile = 0;
    direction = 0;

    FILE *file = fopen("log.txt", "w");
    if (file == NULL)
    {
        return 3;
    }

    greet();

    init();

    while (true)
    {
        clear();

        draw();

        for (int i = 0; i < d; i++)
        {
            for (int j = 0; j < d; j++)
            {
                fprintf(file, "%i", board[i][j]);
                if (j < d - 1)
                {
                    fprintf(file, "|");
                }
            }
            fprintf(file, "\n");
        }
        fflush(file);

        if (done())
        {
            printf("done!\n");
            break;
        }

        printf("move ?");
        int tile = get_int();
        
        if (tile == 0)
        {
            break;
        }

        //fprintf(file, "%i\n", tile);
        fflush(file);

        move();

        usleep(5000);
    }
    
    fclose(file);

    return 0;
}

void clear(void)
{
    printf("\033[2J");
    printf("\033[%d;%dH", 0, 0);
}

void greet(void)
{
    clear();
    printf("Welcome to langton's Ant\n");
    usleep(1000000);
}

void init(void)
{
    int counter = d * d - 1;
    
    for (int i = 0; i < d; i++)
    {
        for (int j = 0; j < d; j++)
        {
            board[i][j] = 0;
            counter --;
        }
    }
    board[d/2][d/2] = 2;
}

void draw(void)
{
    for (int i = 0; i < d; i++)
    {
        for (int j = 0; j < d; j++)
        {
            if (board[i][j] == 0)
            {
                printf(" ");
            }
            if (board[i][j] == 1)
            {
                printf("#");
            }
            if (board[i][j] == 2)
            {
                printf("A");
            }
            if (j < d - 1)
            {
                printf("|");
            }
        }
        printf("\n");
    }
    if(direction == 0)
    {
        printf("direction: UP\n");
    }
    if(direction == 1)
    {
        printf("direction: RIGHT\n");
    }
    if(direction == 2)
    {
        printf("direction: DOWN\n");
    }
    if(direction == 3)
    {
        printf("direction: LEFT\n");
    }
    moves ++;
}

bool move(void)
{
    for (int i = 0; i < d; i++)
    {
        for (int j = 0; j < d; j++)
        {
            if(board[i][j] == 2)
            {
                if(prevTile == 0)
                {
                    if(direction == 0)
                    {
                        if(j + 1 == d)
                        {
                            direction = 1;
                            return true;
                        }
                        prevTile = board[i][j + 1];
                        board[i][j + 1] = 2;
                        board[i][j] = 1;
                        direction = 1;
                        return true;
                    }
                    if(direction == 1)
                    {
                        if(i + 1 == d)
                        {
                            direction = 2;
                            return true;
                        }
                        prevTile = board[i + 1][j];
                        board[i + 1][j] = 2;
                        board[i][j] = 1;
                        direction = 2;
                        return true;
                    }
                    if(direction == 2)
                    {
                        if(j - 1 < 0)
                        {
                            direction = 3;
                            return true;
                        }
                        prevTile = board[i][j - 1];
                        board[i][j - 1] = 2;
                        board[i][j] = 1;
                        direction = 3;
                        return true;
                    }
                    if(direction == 3)
                    {
                        if(i - 1 < 0)
                        {
                            direction = 0;
                            return true;
                        }
                        prevTile = board[i - 1][j];
                        board[i - 1][j] = 2;
                        board[i][j] = 1;
                        direction = 0;
                        return true;
                    }
                }
                if(prevTile == 1)
                {
                    if(direction == 0)
                    {
                        if(j - 1 < 0)
                        {
                            direction = 3;
                            return true;
                        }
                        prevTile = board[i][j - 1];
                        board[i][j - 1] = 2;
                        board[i][j] = 0;
                        direction = 3;
                        return true;
                    }
                    if(direction == 1)
                    {
                        if(i - 1 < 0)
                        {
                            direction = 0;
                            return true;
                        }
                        prevTile = board[i - 1][j];
                        board[i - 1][j] = 2;
                        board[i][j] = 0;
                        direction = 0;
                        return true;
                    }
                    if(direction == 2)
                    {
                        if(j + 1 == d)
                        {
                            direction = 0;
                            return true;
                        }
                        prevTile = board[i][j + 1];
                        board[i][j + 1] = 2;
                        board[i][j] = 0;
                        direction = 1;
                        return true;
                    }
                    if(direction == 3)
                    {
                        if(i + 1 == d)
                        {
                            direction = 2;
                            return true;
                        }
                        prevTile = board[i + 1][j];
                        board[i + 1][j] = 2;
                        board[i][j] = 0;
                        direction = 2;
                        return true;
                    }
                }
            }
        }
    }
    return false;
}

bool done(void)
{
    if(movecount == 0)
    {
        return false;
    }
    if(moves != movecount)
    {
        return false;
    }
    return true;
}
