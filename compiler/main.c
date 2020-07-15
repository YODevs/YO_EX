#include <stdio.h>
#include "cli/cli.h"
#include "cli/parseargs.h"

int main(int argc_i, char *argval[]) {
    if(argc_i > 1)
    {
        //argument available.
        parse_args(argc_i,argval);
    }else{
     //start init cli -- show
    init_main_cli();
    }
    return 0;
}