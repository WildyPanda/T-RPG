from math import *


def lineInfo(X1,Y1,X2,Y2):
    adj = X1 - X2
    opp = Y1 - Y2
    print("Pos  : X:"+ str((X1+X2)/2) + " Y:" + str((Y1+Y2)/2+50))
    print("Rota : X:0, Y:0, Z:" + str(atan(opp/adj) * 57.29578))
    print("Size : X:"+ str(sqrt(adj**2 + opp**2)) + " Y:5")