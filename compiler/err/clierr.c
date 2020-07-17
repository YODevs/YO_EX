//
// Created by AminCoder on 7/15/2020.
//

#include <stdio.h>
#include "clierr.h"
#include "seterr.h"
#include <string.h>
#include <malloc.h>

extern void cli_command_error(char command[])
{
    char caption[200] = "";
    snprintf(caption, sizeof(caption)  , "'%s' - Command not found .",command );
    set_error("Argument Error",caption,exitfproc);
    free(caption);
}

extern void cli_source_notfound_error(char fileaddress[])
{
    char caption[300] = "";
    snprintf(caption, sizeof(caption)  , "'%s' - source not found .",fileaddress );
    set_error("Lexer Error",caption,exitfproc);
    free(caption);
}