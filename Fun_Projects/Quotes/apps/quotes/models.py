# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models

from ..login.models import User


class QuoteManager(models.Manager):
    def quote_validator(self, postData):
        errors = {}
        for key in postData:
            if postData[key] == '':
                errors['empty_field'] = 'All fields are required'
        if len(postData['author']) < 3:
            errors['author'] = 'The name of the person who originally said this quote must be at least 3 characters'
        if len(postData['quote']) < 10:
            errors['quote'] = 'The quote must be at least 10 characters'
        return errors


class Quote(models.Model):
    author = models.CharField(max_length=255)
    message = models.TextField()
    adder = models.ForeignKey(User, related_name='quotes')
    likers = models.ManyToManyField(User, related_name='faves')
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)


    objects = QuoteManager()

#class Join(models.Model):
#    liker = models.ForeignKey(User, related_name='faves')
#    fave = models.ForeignKey(Trip, related_name='likers')
