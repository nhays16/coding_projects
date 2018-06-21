# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render,redirect, HttpResponse
from django.contrib import messages
from .models import *



def dashboard(request):
    if 'user_id' not in request.session:
        return redirect('/main')
    current_user = User.objects.get(id=request.session['user_id'])

    content = {
        'quotes': Quote.objects.exclude(likers=request.session['user_id']),
        'faves': Quote.objects.filter(likers=request.session['user_id']),
        'user': current_user
    }
    return render(request, 'quotes/dashboard.html', content)


def quote_create(request):
    if 'user_id' not in request.session:
        return redirect('/main')

    errors = Quote.objects.quote_validator(request.POST)
    if len(errors):
        for tag, error in errors.iteritems():
            messages.error(request, error, extra_tags=tag)
        return redirect('/quotes')
    else:
        Quote.objects.create(
            author = request.POST['author'],
            message = request.POST['quote'],
            adder = User.objects.get(id=request.session['user_id'])
        )
        return redirect('/quotes')

def user_info(request, user_id):
    if User.objects.filter(id=user_id).exists():
        current_info = User.objects.get(id=user_id)

    count = len(Quote.objects.filter(adder=user_id))

    content = {
        'user': User.objects.get(id=user_id),
        'quotes': Quote.objects.filter(adder=user_id),
        'count' : len(Quote.objects.filter(adder=user_id))
    }
    return render(request, 'quotes/user_info.html', content)

def add_fave(request, quote_id):
    current_user = User.objects.get(id=request.session['user_id'])
    this_quote = Quote.objects.get(id=quote_id)
    this_quote.likers.add(current_user)

    return redirect('/quotes')

def remove_fave(request, quote_id):
    current_user = User.objects.get(id=request.session['user_id'])
    this_quote = Quote.objects.get(id=quote_id)
    current_user.faves.remove(this_quote)

    return redirect('/quotes')

