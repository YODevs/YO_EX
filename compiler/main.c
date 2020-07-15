#include <stdio.h>
#include "cli/cli.h"
int main(int argc_i, char *argval[]) {
    if(argc_i > 1)
    {
        //argument available.
    }else{
     //start init cli -- show
    init_main_cli();
    }
    return 0;
}