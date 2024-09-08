# -*- coding: utf-8 -*-
"""
Inspelning: https://youtu.be/-MLg_Q8LYA8

@author: Emelie Wärmlund
"""


#%% Uppgift 1
import numpy as np
import matplotlib.pyplot as plt
import scipy.integrate as intgr

def y_derivata(y,h): #definierar funktion för att beräkna derivata
    n=len(y) #hämtar storlek på y
    d=np.zeros(n) #skapar array för derivata-värden
     
    for i in range(n): #skapar en loop samma storlek som y
        if i==0: #kollar om index är 0
            d[i]=(y[i+1]-y[i])/h #beräknar framåtdifferensen
        
        elif i==n-1: # kollar om index är sista
            d[i]=(y[i]-y[i-1])/h #beräknar bakåtdifferensen
        
        else: #annars om index är sista  
            d[i]=(y[i+1]-y[i-1])/(2*h) #beräknar centraldifferensen

    return d #returnerar derivatan


x=np.linspace(-2,2,2000) #skapar grid med 2000 punkter
h=x[1]-x[0] #initierar variabel h för gridavståndet 
y=lambda x: x**2 #initierar lambda med funktion

fig,ax=plt.subplots() 
ax.plot(x,y(x),label='f(x)') #plottar funktionen och sätter en label
ax.plot(x,y_derivata(y(x),h),label='f\'\'(x)') #plottar derivatan med label
ax.tick_params(labelsize=12) #sätter tickstorlek
ax.grid('on') #sätter att grid ska visas
ax.legend(fontsize=12 ) #sätter textstorlek på legend
ax.spines['top'].set_visible(False) #sätter att ramlinjen ovan inte ska synas
ax.spines['right'].set_visible(False) #sätter att ramlinjen till höger inte ska synas
ax.spines['left'].set_position('zero') # sätter att x-axel till vänster om origo ska synas
ax.spines['bottom'].set_position('zero') #sätter att y-axel under origo ska synas
plt.show() #visar plot

#%% Uppgift 2a

l_max=68.5 #initierar maxlängden som variabel l_max
l_min=18 #initierar variabel l_min som L(0). Är begynnelsevärdet
r=0.1 #initierar variabel r
x=[0,40] #initierar variabel x som en array för lösningsintervall 0,40
f=lambda t, L:r*(l_max-L) #initierar lambda-funktion f för högerledet av diffekvationen r(Lmax − L)

sol=intgr.solve_ivp(f,x,[l_min],t_eval=np.linspace(0,40,100)) #berärknar diffekvationen inom 0-40 med 100 punkter
    
fig, ax = plt.subplots()
ax.plot(sol.t,sol.y[0]) #plottar sol.t och sol.y som innehåller lösningarna av diffekvationen. sol.t är en vektor sol.y är en matris
ax.set_xlabel('t i år',fontsize=14) #sätter x label för tid
ax.set_ylabel('L i cm',fontsize=14) #sätter y label för längd 
ax.tick_params(labelsize=14) #sätter ticks storlek
plt.show() #visar plot
print(sol) #printar resulat för diffekvationen

#%% Uppgift 2b
import scipy.optimize as opt #laddar optimize i scipy-paketet för beräkning av minstakvadrantanpassnin

def fmodell(a,t):
    f = lambda t, L: a[0]*(a[1]-L) # högerled i diffekv låter a[0] vara k och a[1] vara Lmax
    sol = intgr.solve_ivp(f,[0,40],[a[2]],t_eval = t) #berärknar diffekvationen
    return sol.y[0] #returnerar värde för sol.y

def res(a,tdata,Ldata): #funktion som beräknar residualen
    return Ldata - fmodell(a,tdata)

t=np.array([3,5,7,9,11,13,15,17,19,21]) #initierar array för värden av t i år
L=np.array([25.5,29.1,35.5,41.8,45.5,50.0,53.6,56.4,56.5,58.2]) #initierar array för värden av L i cm

a0=[0.1,68.5,25.5] #startgissningar k=0.1 Lmax=68.5 och L(0)=25.5

a,q=opt.leastsq(res,a0,(t,L)) #gör minstakvadrantanpassning och får parameter a 
print(f'k={round(a[0],2)}, lmax={round(a[1],2)}, L(0)={round(a[2],2)}') #skriver resultatet för a 

fig, ax = plt.subplots()
plt.scatter(t,L) #gör en scatter för grunddata
t_grid = np.linspace(0,40,100) # sätter tätt grid
f = lambda t, L: a[0]*(a[1]-L) #initierar lambda-funktion för högerledet av diffekvationen
sol = intgr.solve_ivp(f,[0,40],[a[2]],t_eval = t_grid) #berärknar diffekvationen inom 0-40 med 100 punkter
ax.plot(t_grid,sol.y[0], color='C1') #plottar diffekvation
ax.set_xlabel('t i år',fontsize=14) #sätter x lavel för t i år
ax.set_ylabel('L i cm',fontsize=14) #sätter y label för l i cm
ax.tick_params(labelsize=14) #sätter ticks storlek
plt.show()

#%% Uppgift 2c

def m_derivata(f,h): #definierar funktion för att beräkna derivata
    n = len(f) #hämtar storlek på funktion
    df=np.zeros(n) #skapar array i samma storlek som f för derivatavärden
    for i in range(n): #skapar for loop i samma storlek som f
        if i == 0: #kollar om index är 0
            df[i] = (f[i+1] - f[i])/h #beräknar framåtdifferensen
        elif i == n-1:  # kollar om index är sista
            df[i] = (f[i] - f[i-1])/h #beräknar bakåtdifferensen
        else:  
            df[i] = (f[i+1] - f[i-1])/(2*h) #beräknar centraldifferensen
    return df #returnerar derivatan


L= sol.y[0] #lösningen för hur rödspättas längd förändras med tid
v=3 #initerar variabel v
k=0.00000892 #initierar variabel k
f=k*L**v #initierar funktion
x = np.linspace(0,40,100) #sätter grid mellan 0 och 40 med 100 punkter
h = x[1] - x[0] #initierar variabel h för griddavstånd

fig, ax = plt.subplots() #initerar variabel för plot M(t)
fig, ax2 = plt.subplots() #initierer variabel för plot M'(t)

ax.plot(x,f) #plottar för M(t)
ax.set_xlabel('t i år',fontsize=14) #sätter x label
ax.set_ylabel('M i kg',fontsize=14) #sätter y label
ax.tick_params(labelsize=14) #sätter tick marks storlek

ax2.plot(x, m_derivata(f, h)) #plottar M'(t)
ax2.set_xlabel('t i år', fontsize=14) # sätter x label
ax2.set_ylabel("dM/dt") #sätter y label

plt.show() #visar plot

print(f'Masstillväxten är som störst vid t= {round(x[np.argmax(m_derivata(f,h))],2)}') #redovisar tid då tillväxten är som störst

#%% Uppgift 3a

a01=0.25 #initierar variabel a1
a10=0.02 #initierar variabel a10
a12=0.05 #initierar variabel a12
M0_min=0.6 #initierar variabel M0
M1_t=0.4 #initierar variabel M1
x=np.linspace(0,20,100) #sätter grid för x-värden. 100 punkter mellan 0 och 20
grid_interval = [0,20] #initierar tidsintervall 

f = lambda t, M: [-a01 * M[0] + a10 * M[1], 
                  a01 * M[0] - (a10 + a12) * M[1] ] #initierar lambdafunktion med högerled och begynnelsevärden

sol = intgr.solve_ivp(f,grid_interval,[0.6, 0.4], t_eval=x) #beräknarsystem av diffekvationer
fig, ax = plt.subplots()  #initierar variabel för fig och ax 
ax.plot(sol.t, sol.y[0], label="plantor") #plottar linje för plantor
ax.plot(sol.t, sol.y[1],ls ="dashed", label="jord") #ritar linje för jord
ax.set_xlabel("t i månader") #sätter x label för tid
ax.set_ylabel("M") #sätter y label för gift
ax.legend(fontsize=12) #sätter legend
plt.show()

## Uppgift 3b
max_gift_jord = x[np.argmax(sol.y[1])] #använder argmax för att hitta maxvärdet av x i y-värden för jord

print(f'Tidpunkt vid högsta giftnivå i jord: {round(max_gift_jord,2)}') #printar resultatet

fig, ax = plt.subplots()  #initierar variabel för fig och ax
ax.plot(sol.t, sol.y[0], label="plantor") #plottar linje för plantor
ax.plot(sol.t, sol.y[1],ls ="dashed", label="jord") #plottar linje för jord
plt.plot(max_gift_jord, max(sol.y[1]), 'ro') #plottar punkt för maxvärde gift för jord
ax.text(max_gift_jord,max(sol.y[1]), f't= {round(max_gift_jord,2)}') #plottar text som redovisar maxvärde gift för jord
ax.set_xlabel("t i månader") #sätter label för x för tid
ax.set_ylabel("M") # sätter y label för gift
ax.legend(fontsize=12) #sätter legend
plt.show()