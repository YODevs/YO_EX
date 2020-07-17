#include <stdio.h>
#include <stdbool.h>
#include "cli/cli.h"
#include "cli/parseargs.h"
#include "xtest/customargs.h"
#include "xtest/invsfile.h"

//Debug / Test constants.
#define INJECTARG false
#define INVOKESOURCEFILE true
//..........................

int main(int argc_i, char *argval[]) {
    if (INJECTARG == true)
    {
        set_custom_argument("yoc.exe build ./main.yo");
        return 0;
    }else if(INVOKESOURCEFILE == true) {
        invoke_build_command("E:\\IX\\main.yo");
        return 0;
    }
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